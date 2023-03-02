using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Teams;
using TournamentApp.Infrastructure.Auth;

namespace TournamentApp.Controllers
{
    [Authorize]
    public class TeamController : BaseController
    {
        private readonly ITeamService _teamService;

        [HttpPost]
        public ActionResult CreateAsync([FromBody] TeamDTO dto)
        {
            return Ok(_teamService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAsync([FromBody] TeamDTO dto, int id)
        {
            _teamService.UpdateAsync(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveAsync(int id)
        {
            _teamService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetAsync(int id)
        {
            return Ok(_teamService.GetAsync(id));
        }

    }
}

