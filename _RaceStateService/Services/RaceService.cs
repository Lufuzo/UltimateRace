using _RaceStateService.Hubs;
using _SharedLayer.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _RaceStateService.Services
{
    public class RaceService : BackgroundService, IRaceService
    {
        private readonly IHubContext<RaceHub> _hub;
        private readonly Random _random = new Random();

        private bool raceRun= false;

        private readonly Scoreboard _scoreboard = new Scoreboard();

        public RaceService(IHubContext<RaceHub> hubRace)
        {
            _hub = hubRace;
        }

        public Scoreboard GetScoreboard() => _scoreboard;

        public void StartRace()
        {
            raceRun = true;
        }

        public void ResetRace()
        {
            raceRun = false;

            _scoreboard.Bikeposition = 0;
            _scoreboard.Teslapostion = 0;
            _scoreboard.Chopperposition = 0;
            _scoreboard.Subposition = 0;
            _scoreboard.Winner = null;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Run race loops only ONCE when the 
            _ = Task.Run(() => StartBike(stoppingToken));
            _ = Task.Run(() => StartTesla(stoppingToken));
            _ = Task.Run(() => StartChopper(stoppingToken));
            _ = Task.Run(() => StartNuclearSub(stoppingToken));

            // Main broadcaster loop
            while (!stoppingToken.IsCancellationRequested)
            {
                if (raceRun)
                    CheckWinner();

                // Push update to clients
                await _hub.Clients.All.SendAsync("ReceiveUpdate", _scoreboard);

                await Task.Delay(400);
            }
        }

        private async Task StartBike(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (raceRun && _scoreboard.Winner == null)
                    _scoreboard.Bikeposition += 20;

                await Task.Delay(1000);
            }
        }

        private async Task StartTesla(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (raceRun && _scoreboard.Winner == null)
                    _scoreboard.Teslapostion += 30;

                await Task.Delay(1000);
            }
        }

        private async Task StartChopper(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (raceRun && _scoreboard.Winner == null)
                    _scoreboard.Chopperposition += 25;

                await Task.Delay(1000);
            }
        }

        private async Task StartNuclearSub(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (raceRun && _scoreboard.Winner == null)
                    _scoreboard.Subposition += 18;

                await Task.Delay(1000);
            }
        }

        private void CheckWinner()
        {
            if (_scoreboard.Winner != null) return;

            if (_scoreboard.Bikeposition >= _scoreboard.DistanceToWin)
                _scoreboard.Winner = "Bike";
            if (_scoreboard.Teslapostion >= _scoreboard.DistanceToWin)
                _scoreboard.Winner = "Tesla";
            if (_scoreboard.Chopperposition >= _scoreboard.DistanceToWin)
                _scoreboard.Winner = "Chopper";
            if (_scoreboard.Subposition >= _scoreboard.DistanceToWin)
                _scoreboard.Winner = "Nuclear Sub";
        }
    }   

}
