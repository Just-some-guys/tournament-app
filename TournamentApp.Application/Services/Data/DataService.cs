using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Auth;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Data
{
    public class DataService : IDataService
    {
        private readonly ITournamentAppContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public DataService(ITournamentAppContext context, IMapper mapper, IAuthService auth)
        {
            _context = context;
            _mapper = mapper;
            _authService = auth;
        }

        public async Task FillData()
        {
            // Создание User

            //for(int i=1; i<= 2; i++)
            //{
            //    RegisterRequest model = new RegisterRequest {
            //        Name = $"UserName{i}",
            //        Password = $"PasswordUser{i}",
            //        ConfirmPassword = $"PasswordUser{i}",
            //        Email = $"UserEmail{i}@gmail.com"
            //    };

            //    await _authService.RegisterAsync(model, "Request.Headers");           

            //}

            List<int> UserIDs = _context.Users.Select(x => x.Id).ToList();

            foreach (int Id in UserIDs)
            {
                _context.Teams.Add(new Team
                {
                    Name = $"Team User{Id}",
                    Icon = "icon",
                    Region = Region.EUW,
                    Players = new List<Player> {new Player
                    {
                        Name = $"SummonerName{Id}",
                        Rank = " ",
                        Role = PlayerRole.Captain,
                        UserId=Id
                    } }

                });

            }

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
