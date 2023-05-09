using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services
{
    public static class Helper
    {
        public static string GetTournamentType(TournamentType type)
        {
            switch (type)
            {   
                case TournamentType.OneByOne: return "OneByOne";

                case TournamentType.PremadeTeam: return "PremadeTeam";

                case TournamentType.OnlyFreeAgents: return "OnlyFreeAgents";

                case TournamentType.PremadeTeamAndFreeAgents: return "PremadeTeamAndFreeAgents";

                default: return "Exception";
            }

        }

        public static string GetTournamentStatus(TournamentStatus status)
        {
            switch (status)
            {
                case TournamentStatus.Feature: return "Feature";

                case TournamentStatus.InProgress: return "InProgress";

                case TournamentStatus.Completed: return "Completed";                

                default: return "Exception";
            }

        }
    }
}
