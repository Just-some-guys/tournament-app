using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Application.Interfaces
{
    public interface IRiotAPIService
    {
        public Task<bool> CheckSummonerNameAsync(string summonerName, string regionName);

        public Task<string> GetSummonerRankAsync(string summonerName, string regionName);
    }
}
