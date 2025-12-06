using _RaceStateService.Services;
using _SharedLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace UltimateRaceSolution.Pages.UltimateRace
{
 
    public class IndexModel : PageModel
    {
        private readonly RaceService _raceService;

        public IndexModel(RaceService raceService)
        {
            _raceService = raceService;
        }

        public Scoreboard Scoreboard { get; set; }

        public void OnGet()
        {
            Scoreboard = _raceService.GetScoreboard();
        }
    }
}
