using Microsoft.AspNetCore.Mvc;
using TournamentApp.Application.Interfaces;

namespace TournamentApp.Controllers
{
    public class DataController: BaseController
    {
        private readonly IDataService _dataService;

        public DataController(IDataService _dataService)
        {
            this._dataService = _dataService;
        }

        [HttpPost]
        public async Task FillData()
        {
            await _dataService.FillData();            
        }
    }
}
