using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Players;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<int> CreateAsync(PlayerDTO dto, int teamId);
        Task RemoveAsync(int id);
        Task UpdateAsync(PlayerUpdateDTO dto, int id);
        Task<PlayerGetDTO> GetDTOAsync(int id);
        Task<Player> GetAsync(int id);
    }
}
