using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TournamentApp.Application.Common.Exceptions;
using TournamentApp.Application.Interfaces;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Users;
public class UserService : IUserService
{
    private readonly ITournamentAppContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(ITournamentAppContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<User> GetByRefreshTokenAsync(string refreshToken)
    {
        var account = _context.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        if (account == null) throw new InvalidTokenException();

        return account;
    }

    public User GetCurrentUser() => (User)_httpContextAccessor.HttpContext.Items["User"];
}
