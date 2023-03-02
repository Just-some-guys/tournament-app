using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Application.Interfaces
{
    public interface IRiotAPIService
    {
        public bool CheckSummonerName(string summonerName);

        public Task<string> GetSummonerRankAsync(string summonerName);
    }
}
