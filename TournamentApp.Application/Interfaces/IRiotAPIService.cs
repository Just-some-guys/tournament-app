using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Interfaces
{
    public interface IRiotAPIService
    {
        public Task<bool> CheckSummonerNameAsync(string summonerName, Region region);

        public Task<string> GetSummonerRankAsync(string summonerName, Region region);
    }
}
