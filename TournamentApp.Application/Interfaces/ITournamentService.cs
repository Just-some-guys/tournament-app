using TournamentApp.Application.Models.Tournaments;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Application.Services.Tournaments;
public interface ITournamentService
{
    Task<int> CreateAsync(TournamentDTO dto);
    Task<TournamentGetDTO> GetAsync(int id);
    Task<List<TournamentPreviewDTO>> GetFiltredTournamentsAsync(Discipline discipline, DateTime? startDate, DateTime? endDate, TournamentType? type);
    Task<List<TournamentGetDTO>> GetHistoryByUserIdAsync(int userId);
    Task<List<TournamentGetDTO>> GetTournamentsAsync();
    Task GetUserTournaments(int userId);
    Task RemoveAsync(int id);
    Task UpdateAsync(TournamentDTO dto, int id);
}