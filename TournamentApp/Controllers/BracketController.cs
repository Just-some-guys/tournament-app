﻿using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;
using TournamentApp.Domain.Entities.BracketEntities;

namespace TournamentApp.Controllers
{
    public class BracketController: BaseController
    {
        private readonly IBracketService _bracketService;

        public BracketController(IBracketService _bracketService)
        {
            this._bracketService = _bracketService;
        }

        [HttpGet]
        public DoubleEliminationModel GetDEModel()
        {
            return _bracketService.GetDEModel();
        }
    }
}
