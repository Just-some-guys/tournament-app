using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Organizations;

namespace TournamentApp.Application.Interfaces
{
    public interface IOrganizationService
    {
        Task<int> CreateAsync(OrganizationCreateDTO dto);        
        Task UpdateAsync(OrganizationUpdateDTO dto);
        Task RemoveAsync(int id);
    }
}
