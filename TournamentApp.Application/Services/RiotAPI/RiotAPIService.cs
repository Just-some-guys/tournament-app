using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;

namespace TournamentApp.Application.Services.RiotAPI
{
    public class RiotAPIService : IRiotAPIService
    {
        public async Task<bool> CheckSummonerNameAsync(string summonerName, string regionName)
        {
            return true; // Пока проверка будет всегда удачной
        }

        public async Task<string> GetSummonerRankAsync(string summonerName, string regionName)
        {
            string result = "Ранг полученный из RiotAPI";
            
            return result;
        }
    }
}
