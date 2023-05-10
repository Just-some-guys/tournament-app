using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Teams;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Interfaces
{
    public interface ITeamService
    {
        Task<int> CreateAsync(TeamDTO dto);
        Task RemoveAsync(int id);
        Task UpdateAsync(TeamUpdateDTO dto, int id);
        Task<Team> GetAsync(int id);
        Task<Team> GetByPlayerIdAsync(int playerId);
        Task<TeamGetDTO> GetDTOAsync(int id);

    }
}
