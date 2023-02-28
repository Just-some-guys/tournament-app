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
        Task<int> CreateAsync(PlayerDTO dto);
        Task RemoveAsync(int id);
        Task UpdateAsync(PlayerDTO dto, int id);
        Task<PlayerDTO> GetAsync(int id);
    }
}
