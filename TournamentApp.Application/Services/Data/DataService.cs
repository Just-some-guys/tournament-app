using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Data
{
    public class DataService : IDataService
    {
        private readonly ITournamentAppContext _context;
        private readonly IMapper _mapper;

        public DataService(ITournamentAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void FillData()
        {
            User user = _context.Users.FirstOrDefault(_ => _.Id == 1);

            for(int i=0; i< 16; i++)
            {
                _context.Users.Add(new User
                {

                });
            }

            Team team = new Team
            {
                Name = "Team Name 1",
                Players = new List<Player>(),
                Icon = "icon",
                Region = "EUW",
                Captain = user
            };


            Player player = new Player { Name = "PlayerName1" };
        }
    }
}
