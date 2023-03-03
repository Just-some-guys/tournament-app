using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TournamentApp.Application.Common.Configs;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Services.Players;
using TournamentApp.Application.Services.Teams;
using TournamentApp.Application.Services.Tournaments;
using TournamentApp.Application.Services.Users;

namespace TournamentApp.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IPlayerService, PlayerService>();
        services.AddTransient<ITeamService, TeamService>();
        services.AddTransient<ITournamentService, TournamentService>();
        services.Configure<EmailConfig>(configuration.GetSection(nameof(EmailConfig)));
        services.Configure<SecurityConfig>(configuration.GetSection(nameof(SecurityConfig)));

        return services;
    }
}
