using _RaceStateService.Services;
using _SharedLayer.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _RaceStateService.Hubs
{
    public class RaceHub : Hub
    {

        private readonly RaceService _raceService;

        public RaceHub(RaceService raceService)
        {
            _raceService = raceService;
        }

        public async Task StartRace()
        {
            _raceService.StartRace();
            await Clients.All.SendAsync("RaceState", "started");
        }

        public async Task ResetRace()
        {
            _raceService.ResetRace();
            await Clients.All.SendAsync("RaceState", "reset");
        }

    }
}
