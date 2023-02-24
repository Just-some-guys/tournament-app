using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TournamentApp.Application.Interfaces;
using TournamentApp.Infrastructure.Persistence;

namespace TournamentApp.Infrastructure.Auth;
public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, TournamentAppContext dbContext, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var accountId = jwtUtils.ValidateJwtToken(token);
        if (accountId != null)
        {
            context.Items["User"] = await dbContext.Users.FindAsync(accountId.Value);
        }

        await _next(context);
    }
}
