using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Application.Models.Tournaments;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Interfaces
{
    public interface ITournamentService
    {
        Task<int> CreateAsync(TournamentDTO dto);
        Task RemoveAsync(int id);
        Task<TournamentGetDTO> GetAsync(int id);
        Task UpdateAsync(TournamentDTO DTO, int id);        
        Task <List<TournamentGetDTO>> GetHistoryByUserIdAsync (int UserId);
        Task<List<TournamentPreviewDTO>> GetFiltredTournamentsAsync(Discipline discipline, DateTime? startDate, DateTime? endDate, TournamentType? type);
    }
}
