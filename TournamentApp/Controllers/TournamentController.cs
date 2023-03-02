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

        [HttpPost("CreateAsync")]
        public ActionResult CreateAsync([FromBody] TournamentDTO dto)
        {
            return Ok(_tournamentService.CreateAsync(dto));
        }

        [HttpPut("UpdateAsync")]
        public ActionResult UpdateAsync([FromBody] TournamentDTO dto, int id)
        {
            _tournamentService.UpdateAsync(dto, id);
            return Ok();
        }

        [HttpDelete("DeleteAsync")]
        public ActionResult RemoveAsync(int id)
        {
            _tournamentService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("GetAsync")]
        public ActionResult GetAsync(int id)
        {
            return Ok(_tournamentService.GetAsync(id));
        }
    }
}


