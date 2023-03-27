using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TournamentApp.Application.Interfaces;
using TournamentApp.Infrastructure.Auth;
using TournamentApp.Infrastructure.Email;
using TournamentApp.Infrastructure.Persistence;

namespace TournamentApp.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TournamentAppContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<ITournamentAppContext>(provider => provider.GetRequiredService<TournamentAppContext>());
        services.AddScoped<DbInitializer>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtUtils, JwtUtils>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddHttpContextAccessor();

        return services;
    }
}
