using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Teams;

namespace TournamentApp.Application.Interfaces
{
    public interface ITeamService
    {
        Task<int> CreateAsync(TeamDTO dto);
        Task RemoveAsync(int id);
        Task UpdateAsync(TeamDTO dto, int id);
        Task <TeamGetDTO> GetAsync(int id);
    }
}
