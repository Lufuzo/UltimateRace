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

        private bool raceRunning = false;

        private readonly Scoreboard _scoreboard = new Scoreboard();

        public RaceService(IHubContext<RaceHub> hub)
        {
            _hub = hub;
        }

        public Scoreboard GetScoreboard() => _scoreboard;

        public void StartRace()
        {
            raceRunning = true;
        }

        public void ResetRace()
        {
            raceRunning = false;

            _scoreboard.Bike = 0;
            _scoreboard.Tesla = 0;
            _scoreboard.Chopper = 0;
            _scoreboard.Sub = 0;
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
                if (raceRunning)
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
                if (raceRunning && _scoreboard.Winner == null)
                    _scoreboard.Bike += 20;

                await Task.Delay(1000);
            }
        }

        private async Task StartTesla(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (raceRunning && _scoreboard.Winner == null)
                    _scoreboard.Tesla += 30;

                await Task.Delay(1000);
            }
        }

        private async Task StartChopper(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (raceRunning && _scoreboard.Winner == null)
                    _scoreboard.Chopper += 25;

                await Task.Delay(1000);
            }
        }

        private async Task StartNuclearSub(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (raceRunning && _scoreboard.Winner == null)
                    _scoreboard.Sub += 18;

                await Task.Delay(1000);
            }
        }

        private void CheckWinner()
        {
            if (_scoreboard.Winner != null) return;

            if (_scoreboard.Bike >= _scoreboard.DistanceToWin)
                _scoreboard.Winner = "Bike";
            if (_scoreboard.Tesla >= _scoreboard.DistanceToWin)
                _scoreboard.Winner = "Tesla";
            if (_scoreboard.Chopper >= _scoreboard.DistanceToWin)
                _scoreboard.Winner = "Chopper";
            if (_scoreboard.Sub >= _scoreboard.DistanceToWin)
                _scoreboard.Winner = "Nuclear Sub";
        }
    }   

}
