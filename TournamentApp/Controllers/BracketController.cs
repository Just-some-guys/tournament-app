using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Brackets;
using TournamentApp.Domain.Entities.BracketEntities;

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
            return _bracketService.GetDEModelDtoAuto();
        }

        [HttpGet("DoubleBracket")]
        public DoubleEliminationBracket CreateDoubleEliminationBracket()
        {
            return _bracketService.CreateDoubleEliminationBracket();
        }

        [HttpGet("SingleBracket")]
        public SingleEliminationBracket CreateSingleEliminationBracket()
        {
            return _bracketService.CreateSingleEliminationBracket(); ;
        }

        [HttpGet("CreateDEModel")]
        public void CreateDEModel(int TournamentId)
        {
            _bracketService.CreateDEModel(TournamentId);
        }
    }
}
