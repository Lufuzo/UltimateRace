using System;
namespace ultimaterace
{
    public class Vehicle
    {
        public Vehicle()
        {
        }

        // Robinson R22
        public int chopperfuelcapacitygallons = 20;
        public int chopperFuelUsageperhourgallons = 8;
        public int chopperAvgSpeedkmh = 180;    // Traveling in the air. No limits!
        public int choppertimetorefuelhrs = 3;
        public double chopperbreakdownprobability = 0.2;

        // KTM 450 Rally
        public double bikefueltankliters = 33.6;
        public double bikekmperlitre = 8;
        public int bikespeedmph = 100;      // Traveling on dirt roads. No cops there!
        public double biketimetorefuelhrs = 0.5;
        public double bikebreakdownprobability = 0.5;

        // Tesla Model-S
        public int teslaenginekw = 310;
        public int teslabatterypack = 700;
        public int teslaspeed = 120;    // Traveling on public roads.
        public double teslatimetorefuelhrs = 1;
        public double teslabreakdownprobability = 0.1;

        // Virginia-Class Submarine
        public int nuclearsubspeedknots = 35; 
        public double subbreakdownprobability = 0.0;
    }
}
