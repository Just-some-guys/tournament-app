using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Players;

namespace TournamentApp.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<int> CreateAsync(PlayerDTO dto, int teamId);
        Task RemoveAsync(int id);
        Task UpdateAsync(PlayerUpdateDTO dto, int id);
        Task<PlayerGetDTO> GetAsync(int id);
    }
}
