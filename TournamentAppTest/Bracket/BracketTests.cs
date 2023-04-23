using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Domain.Entities;

namespace TournamentAppTest.Bracket
{
    public class BracketTests : BaseTestFixture
    {       
        [Test]
        public async Task CreateDEModel()
        {
            using (var scope = Testing._scopeFactory.CreateScope())
            {
                var DataService = scope.ServiceProvider.GetRequiredService<IDataService>();
                var BracketService = scope.ServiceProvider.GetRequiredService<IBracketService>();
                var _context = scope.ServiceProvider.GetRequiredService<ITournamentAppContext>();

                await DataService.RemoveData();
                await DataService.FillData();
                int tournamentId = _context.Tournaments.First().Id;

                await BracketService.CreateDEModel(tournamentId);

                Tournament tournament = _context.Tournaments.First();
            }

            
        }

    }
}
