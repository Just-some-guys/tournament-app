using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Organizations;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Interfaces
{
    public interface IOrganizationService
    {
        Task<int> CreateAsync(OrganizationCreateDTO dto);        
        Task UpdateAsync(OrganizationUpdateDTO dto, int id);
        Task RemoveAsync(int id);
        Task <OrganizationGetDTO> GetDTOAsync(int id);
        Task<Organization> GetAsync(int id);
        Task<List<UserOrganizationGetDTO>> GetUserOrganizations(int UserId);
    }
}
