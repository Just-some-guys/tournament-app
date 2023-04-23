using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Infrastructure.Persistence;

namespace TournamentAppTest
{
    internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(configurationBuilder =>
            {
                var integrationConfig = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();

                configurationBuilder.AddConfiguration(integrationConfig);
            });

            builder.ConfigureServices((builder, services) =>
            {
                services
                    .Remove<DbContextOptions<TournamentAppContext>>()
                    .AddDbContext<TournamentAppContext>((sp, options) =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("IwpDatabase"),
                            builder => builder.MigrationsAssembly(typeof(TournamentAppContext).Assembly.FullName)));
            });
        }
    }
}
