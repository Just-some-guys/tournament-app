﻿using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;
using TournamentApp.Application.Models.Tournaments;
using TournamentApp.Application.Services.Tournaments;
using TournamentApp.Domain.Entities;

namespace TournamentApp.Controllers
{
    public class TournamentController : BaseController
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService _tournamentService)
        {
            this._tournamentService = _tournamentService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] TournamentDTO dto)
        {
            return Ok(await _tournamentService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] TournamentUpdateDTO dto, int id)
        {
            await _tournamentService.UpdateAsync(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _tournamentService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _tournamentService.GetDTOAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult> GetTournamentsAsync()
        {
            return Ok(await _tournamentService.GetTournamentsAsync());
        }
                

        [HttpGet("top")]
        public async Task<ActionResult> GetTopAsync()
        {
            var tournaments = new List<TournamentGetDTO>
            {
                new TournamentGetDTO
                {
                    Name= "name1",
                    StartDate= DateTime.Now.AddDays(5)
                },
                new TournamentGetDTO
                {
                      Name= "name2",
                    StartDate= DateTime.Now.AddDays(4)
                },
                new TournamentGetDTO
                {
                      Name= "name3",
                    StartDate= DateTime.Now.AddDays(3)
                },
                new TournamentGetDTO
                {
                      Name= "name4",
                    StartDate= DateTime.Now.AddDays(2)
                },
                new TournamentGetDTO
                {
                      Name= "name5",
                    StartDate= DateTime.Now.AddDays(1)
                }
            };
            return Ok(tournaments);
        }

        [HttpGet("{organizationId}/{status}")]
        public async Task<ActionResult> GetTournamentsItemDTO(int organizationId, TournamentStatus status)
        {
            return Ok( await _tournamentService.GetTournamentsItemDTO(organizationId, status));
        }
    }
}
