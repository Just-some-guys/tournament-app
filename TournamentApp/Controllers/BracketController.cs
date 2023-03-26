using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Brackets;

namespace TournamentApp.Controllers
{
    public class BracketController : BaseController
    {
        private readonly IBracketService _bracketService;

        public BracketController(IBracketService _bracketService)
        {
            this._bracketService = _bracketService;
        }

        [HttpGet("Auto")]
        public DoubleEliminationBracketDto GetDEModelAuto()
        {
            return _bracketService.GetDEModelAuto();
        }
    }
}
