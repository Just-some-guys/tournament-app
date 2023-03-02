using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Players;
using TournamentApp.Infrastructure.Auth;

namespace TournamentApp.Controllers
{    

    public class PlayerController: BaseController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService _playerService)
        {
            this._playerService = _playerService;
        }

        [HttpPost("{teamId}")]
        public async  Task<ActionResult> CreateAsync([FromBody] PlayerDTO dto, int teamId )
        {
            return Ok( await _playerService.CreateAsync(dto, teamId));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] PlayerUpdateDTO dto, int id)
        {
            await _playerService.UpdateAsync(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _playerService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            return Ok(await _playerService.GetAsync(id));
        }
    }
}

