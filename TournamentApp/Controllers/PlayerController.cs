using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Players;
using TournamentApp.Infrastructure.Auth;

namespace TournamentApp.Controllers
{
    

    [Authorize]
    public class PlayerController: BaseController
    {
        private readonly IPlayerService _playerService;


        [HttpPost("{teamId}")]
        public ActionResult CreateAsync([FromBody] PlayerDTO dto, int teamId )
        {
            return Ok(_playerService.CreateAsync(dto, teamId));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAsync([FromBody] PlayerDTO dto, int id)
        {
            _playerService.UpdateAsync(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveAsync(int id)
        {
            _playerService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetAsync(int id)
        {
            return Ok(_playerService.GetAsync(id));
        }
    }
}

