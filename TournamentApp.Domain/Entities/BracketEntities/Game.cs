using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    public class Game : Entity
    {
        // это не одна игра, а серия игр

        public Match Match { get; set; }
        public int MatchId { get; set; }

        public Team TeamNumberOne { get; set; }
        public int TeamNumberOneId { get; set; }        
                                                         // Скорее всего команды в этой сущности не нужны
        public Team TeamNumberTwo { get; set; }
        public int TeamNumberTwoId { get; set; }

        public Team Winner { get; set; }
        public int WinnerId { get; set; }

        public string GameFromRiotAPI { get; set; } // поле для поиска игры в RiotAPI
    }
}
