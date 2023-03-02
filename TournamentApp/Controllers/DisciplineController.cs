using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Disciplines;

namespace TournamentApp.Controllers
{
    public class DisciplineController: BaseController
    {
        private readonly IDisciplineService _disciplineService;

        public DisciplineController(IDisciplineService _disciplineService)
        {
            this._disciplineService = _disciplineService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] DisciplineDTO dto)
        {
            return Ok(await _disciplineService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] DisciplineDTO dto, int id)
        {
            await _disciplineService.UpdateAsync(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _disciplineService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            return Ok(await _disciplineService.GetAsync(id));
        }

    }
}
