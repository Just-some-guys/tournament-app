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
        public bool CheckSummonerName(string summonerName)
        {
            return true; // Пока проверка будет всегда удачной
        }

        public async Task<string> GetSummonerRankAsync(string summonerName)
        {
            string result = "Ранг полученный из RiotAPI";
            
            return result;
        }
    }
}
