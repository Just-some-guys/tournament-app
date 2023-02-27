using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Team;

namespace TournamentApp.Application.Interfaces
{
    public interface ITeamService
    {
        Task<int> Create(TeamCreateDTO DTO);
        Task Remove(int Id);
    }
}
