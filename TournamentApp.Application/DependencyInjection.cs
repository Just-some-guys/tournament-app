using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TournamentApp.Application.Common.Configs;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Users;

namespace TournamentApp.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<IUserService, UserService>();
        services.Configure<EmailConfig>(configuration.GetSection(nameof(EmailConfig)));
        services.Configure<SecurityConfig>(configuration.GetSection(nameof(SecurityConfig)));

        return services;
    }
}
