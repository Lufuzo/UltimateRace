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

        private int trckpostion;
        public int truckposition { get; set; }
      
        private int chprposition;
        public int chopperposition { get; set; }

        private int bkposition;
        public int bikeposition { get; set; }
       
        private int lwnmower;
        public int lawnmowerposition { get; set; }

        private int tsla;
        public int teslapostion { get; set; }
       
        private int sub;
        public int subposition { get; set; }
        


        public int Bike { get; set; }
        public int Tesla { get; set; }
        public int Chopper { get; set; }
        public int Sub { get; set; }

        public int DistanceToWin { get; set; } = 5000; 

        public string? Winner
        {
            get; set;
        }
    }
}
