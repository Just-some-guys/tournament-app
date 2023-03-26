using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.OrganizationMembers;

namespace TournamentApp.Application.Interfaces
{
    public interface IOrganizationMemberService
    {
        Task<int> CreateAsync(OrganizationMemberCreateDTO dto);        
        Task RemoveAsync(int id);
    }
}
