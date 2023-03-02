using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Tournaments;
using TournamentApp.Infrastructure.Auth;

namespace TournamentApp.Controllers
{
    [Authorize]
    public class TournamentController:BaseController
    {
        private readonly ITournamentService _tournamentService;

        [HttpPost]
        public ActionResult CreateAsync([FromBody] TournamentDTO dto)
        {
            return Ok(_tournamentService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAsync([FromBody] TournamentDTO dto, int id)
        {
            _tournamentService.UpdateAsync(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveAsync(int id)
        {
            _tournamentService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetAsync(int id)
        {
            return Ok(_tournamentService.GetAsync(id));
        }
    }
}


