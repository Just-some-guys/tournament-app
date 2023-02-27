using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using TournamentApp.Application.Common.Configs;
using TournamentApp.Application.Common.Exceptions;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Auth;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Infrastructure.Auth;
public class AuthService : IAuthService
{
    private readonly ITournamentAppContext _context;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly IJwtUtils _jwtUtils;
    private readonly IUserService _userService;
    private readonly SecurityConfig _securityConfig;

    public AuthService(
        ITournamentAppContext context,
        IMapper mapper,
        IEmailService emailService,
        IJwtUtils jwtUtils,
        IOptions<SecurityConfig> securityConfig,
        IUserService userService)
    {
        _context = context;
        _mapper = mapper;
        _emailService = emailService;
        _jwtUtils = jwtUtils;
        _userService = userService;
        _securityConfig = securityConfig.Value;
    }

    public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model)
    {
        var user = await _context.Users.Include(u => u.RefreshTokens).SingleOrDefaultAsync(x => x.Email == model.Email);

        if (user == null || !user.IsVerified || !BCrypt.Net.BCrypt.Verify(model.Password, user.Hash))
            throw new InvalidCredentialsException();

        var jwtToken = _jwtUtils.GenerateJwtToken(user);
        var refreshToken = await _jwtUtils.GenerateRefreshTokenAsync();
        user.RefreshTokens.Add(refreshToken);

        RemoveOldRefreshTokens(user);

        _context.Users.Update(user);
        await _context.SaveChangesAsync(default);

        var response = _mapper.Map<AuthenticateResponse>(user);
        response.JwtToken = jwtToken;

        return response;
    }

    public async Task<AuthenticateResponse> RefreshTokenAsync(string token)
    {
        var user = await _userService.GetByRefreshTokenAsync(token);
        var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

        if (refreshToken.IsActive)
            throw new InvalidTokenException();

        var newRefreshToken = await _jwtUtils.GenerateRefreshTokenAsync();
        user.RefreshTokens.Add(newRefreshToken);

        _context.Users.Update(user);
        await _context.SaveChangesAsync(default);

        var jwtToken = _jwtUtils.GenerateJwtToken(user);

        var response = _mapper.Map<AuthenticateResponse>(user);
        response.JwtToken = jwtToken;
        response.RefreshToken = newRefreshToken.Token;

        return response;
    }

    public async Task RegisterAsync(RegisterRequest model, string origin)
    {
        if (await _context.Users.AnyAsync(x => x.Email == model.Email))
        {
            return;
        }

        var user = new User { Email = model.Email };
        user.Created = DateTime.UtcNow;
        user.VerificationToken = GenerateVerificationToken();

        user.Hash = BCrypt.Net.BCrypt.HashPassword(model.Password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync(default);

        await SendVerificationEmailAsync(user, origin);
    }

    public async Task VerifyEmailAsync(string token)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.VerificationToken == token);

        if (user == null)
            throw new InvalidTokenException();

        user.Verified = DateTime.UtcNow;
        user.VerificationToken = null;

        _context.Users.Update(user);
        await _context.SaveChangesAsync(default);
    }

    private string GenerateVerificationToken()
    {
        var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

        var tokenIsUnique = !_context.Users.Any(x => x.VerificationToken == token);
        if (!tokenIsUnique)
            return GenerateVerificationToken();

        return token;
    }

    private void RemoveOldRefreshTokens(User user)
    {
        user.RefreshTokens.RemoveAll(x =>
            !x.IsActive &&
            x.Created.AddDays(_securityConfig.RefreshTokenTTL) <= DateTime.UtcNow);
    }

    private async Task SendVerificationEmailAsync(User user, string origin)
    {
        string message;
        if (!string.IsNullOrEmpty(origin))
        {
            var verifyUrl = $"{origin}/api/Auth/verify-email?token={user.VerificationToken}";
            message = $@"<p>Please click the below link to verify your email address:</p>
                            <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
        }
        else
        {
            message = $@"<p>Please use the below token to verify your email address with the <code>/api/Auth/verify-email</code> api route:</p>
                            <p><code>{user.VerificationToken}</code></p>";
        }

        await _emailService.SendAsync(
            to: user.Email,
            subject: "Sign-up Verification API - Verify Email",
            html: $@"<h4>Verify Email</h4>
                        <p>Thanks for registering!</p>
                        {message}"
        );
    }
}
