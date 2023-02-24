using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Auth.Models;
using TournamentApp.Application.Interfaces;
using TournamentApp.Infrastructure.Auth;

namespace TournamentApp.Controllers;

[Authorize]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<AuthenticateResponse>> AuthenticateAsync(AuthenticateRequest authenticateRequest)
    {
        return Ok(await _authService.AuthenticateAsync(authenticateRequest));
    }

    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public async Task<ActionResult<AuthenticateResponse>> RefreshTokenAsync()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var refreshTokenResponse = await _authService.RefreshTokenAsync(refreshToken);
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };
        Response.Cookies.Append("refreshToken", refreshTokenResponse.RefreshToken, cookieOptions);

        return Ok(refreshTokenResponse);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest registerRequest)
    {
        await _authService.RegisterAsync(registerRequest, Request.Headers["origin"]);

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("verify-email/{token}")]
    public async Task<IActionResult> VerifyEmailAsync(string token)
    {
        await _authService.VerifyEmailAsync(token);

        return Ok();
    }
}
