using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Player;

namespace TournamentApp.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<int> Create(PlayerCreateDTO DTO);
        Task Remove(int Id);
    }
}
