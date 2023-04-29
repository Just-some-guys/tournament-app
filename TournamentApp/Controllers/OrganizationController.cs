using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;

namespace TournamentApp.Controllers
{
    public class OrganizationController: BaseController
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService _organizationService)
        {
            this._organizationService = _organizationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            return Ok(await _organizationService.GetAsync(id));
        }
    }
}
