using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _SharedLayer.Models
{
    public class Scoreboard
    {
        public int chopperdistancetotraveltowin = 7400;
        public int bikedistancetotraveltowin = 9800;
        public int tesladistancetotraveltowin = 10200;
        public int subdistancetotraveltowin = 11500;    
        public int Truckposition { get; set; } 
        public int Chopperposition { get; set; }
        public int Bikeposition { get; set; }
        public int Lawnmowerposition { get; set; }
        public int Teslapostion { get; set; }
        public int Subposition { get; set; }
        public int DistanceToWin { get; set; } = 5000; 
        public string? Winner
        {
            get; set;
        }
    }
}
