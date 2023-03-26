using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Tournaments;

namespace TournamentApp.Controllers
{
    public class TournamentController : BaseController
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService _tournamentService)
        {
            this._tournamentService = _tournamentService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] TournamentDTO dto)
        {
            return Ok(await _tournamentService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] TournamentDTO dto, int id)
        {
            await _tournamentService.UpdateAsync(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _tournamentService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            return Ok(await _tournamentService.GetAsync(id));
        }
    }
}
