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
        Scoreboard GetScoreboard();
        void StartRace();
        void ResetRace();
    }
}
