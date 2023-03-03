using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Disciplines;

namespace TournamentApp.Application.Interfaces
{
    public interface IDisciplineService
    {
        Task<int> CreateAsync(DisciplineDTO dto);
        Task RemoveAsync(int id);
        Task UpdateAsync(DisciplineDTO dto, int id);
        Task<DisciplineGetDTO> GetAsync(int id);
    }
}
