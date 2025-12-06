using _SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _RaceStateService.Services
{
    public interface IRaceService 
    {
        /// <summary>
        /// Returns the current scoreboard values.
        /// </summary>
        Scoreboard GetScoreboard();

        /// <summary>
        /// Starts the race loop.
        /// </summary>
        void StartRace();

        /// <summary>
        /// Resets all racer values and stops the race.
        /// </summary>
        void ResetRace();
    }
}
