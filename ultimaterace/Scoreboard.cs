using System;
namespace ultimaterace
{
    public class Scoreboard
    {
        public Scoreboard()
        {
        }

        public int chopperdistancetotraveltowin = 7400;
        public int bikedistancetotraveltowin = 9800;
        public int tesladistancetotraveltowin = 10200;
        public int subdistancetotraveltowin = 11500;

        private int trckpostion;
        public int truckposition
        {
            set
            {
                trckpostion = value;
            }
            get
            {
                return trckpostion;
            }
        }

        private int chprposition;
        public int chopperposition
        {
            set
            {
                chprposition = value;
            }
            get
            {
                return chprposition;
            }
        }

        private int bkposition;
        public int bikeposition
        {
            set
            {
                bkposition = value;
            }
            get
            {
                return bkposition;
            }
        }

        private int lwnmower;
        public int lawnmowerposition
        {
            get
            {
                return lwnmower;
            }
            set
            {
                lwnmower = value;
            }
        }

        private int tsla;
        public int teslapostion
        {
            get
            {
                return tsla;
            }
            set
            {
                tsla = value;
            }
        }

        private int sub;
        public int subposition
        {
            get
            {
                return sub;
            }
            set
            {
                sub = value;
            }
        }
    }
}
