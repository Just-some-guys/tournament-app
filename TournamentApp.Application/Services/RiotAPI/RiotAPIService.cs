using RiotSharp;
using RiotSharp.Misc;
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
        RiotApi api = RiotApi.GetDevelopmentInstance("RGAPI-418a545a-3a37-4bd1-91ee-fa479b293cb1");

        private Region GetRegion(string name)
        {
            return name switch
            {
                "Euw" => Region.Euw,
                "Eune" => Region.Eune,
                _=> throw new Exception("Регион не определён"),
            };
        }
        public async Task<bool> CheckSummonerNameAsync(string summonerName, TournamentApp.Domain.Entities.Region region)
        {
            var summoner =  await api.Summoner.GetSummonerByNameAsync(GetRegion(region.ToString()), summonerName);
            if (summoner == null)
            {
                throw new Exception("Саммонер не найден");
                return false;
            }
            return true;
        }

        public async Task<string> GetSummonerRankAsync(string summonerName, TournamentApp.Domain.Entities.Region region)
        {
            string result = "Ранг полученный из RiotAPI";
            
            return result;
        }
    }
}
