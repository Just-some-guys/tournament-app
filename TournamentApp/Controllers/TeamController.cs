using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Teams;
using TournamentApp.Infrastructure.Auth;

namespace TournamentApp.Controllers
{
    public class TeamController : BaseController
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService _teamService)
        {
            this._teamService = _teamService;
        }
        [HttpPost]
        public async Task< ActionResult> CreateAsync([FromBody] TeamDTO dto)
        {
            return Ok( await _teamService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async  Task<ActionResult> UpdateAsync([FromBody] TeamUpdateDTO dto, int id)
        {
            await _teamService.UpdateAsync(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async  Task<ActionResult> RemoveAsync(int id)
        {
            await _teamService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            return Ok( await _teamService.GetAsync(id));
        }


    }
}

