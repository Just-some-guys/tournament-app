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
        public RoundType RoundType { get; set; }

        public Team TeamNumberOne { get; set; }
        public int TeamNumberOneId { get; set; }
        public int TeamNumberOneScore{ get; set; }

        public Team TeamNumberTwo { get; set; }
        public int TeamNumberTwoId { get; set; }
        public int TeamNumberTwoScore { get; set; }

        public Round Round { get; set; }
        public int RoundId { get; set; }

        public Team Winner { get; set; }
        public int WinnerId { get; set; }



        // Количество игр будет меняться в зависимости от RoundType BO1, BO3, BO5
        public List<string> GamesFromRiotAPI { get; set; } // Не уверен что это нужно и какой тип данных использовать
    }
}
