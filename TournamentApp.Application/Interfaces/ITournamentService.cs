using TournamentApp.Application.Models.Tournaments;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Interfaces
{
    public interface ITournamentService
    {
        Task<int> CreateAsync(TournamentDTO dto);
        Task RemoveAsync(int id);
        Task<TournamentGetDTO> GetDTOAsync(int id);
        Task<Tournament> GetAsync(int id);
        Task UpdateAsync(TournamentUpdateDTO dto, int id);
        Task <List<TournamentPreviewDTO>> GetTournamentsAsync();        
        Task <List<TournamentGetDTO>> GetHistoryByUserIdAsync (int UserId);
        Task<List<TournamentPreviewDTO>> GetFiltredTournamentsAsync(DateTime? startDate, DateTime? endDate, TournamentType? type);
        Task<List<TournamentListItemDTO>> GetTournamentsItemDTO(int organizationId, TournamentStatus status);

        
    }
}
