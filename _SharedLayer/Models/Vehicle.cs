using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SharedLayer.Models
{
    public class Vehicle
    {
        // Robinson R22
        public int ChopperAvgSpeedKmh { get; set; } = 180;
        public int ChopperFuelCapacityGallons { get; set; } = 20;
        public int ChopperFuelUsagePerHourGallons { get; set; } = 8;
        public double ChopperBreakProb { get; set; } = 0.02;

        public int Choppertimetorefuelhrs = 3;

        public double Chopperbreakdownprobability = 0.2;

        // KTM 450 Rally
        public double Bikefueltankliters = 33.6;
        public double Bikekmperlitre = 8;
        public int Bikespeedmph = 100;      // Traveling on dirt roads. No cops there!
        public double Biketimetorefuelhrs = 0.5;
        public double Bikebreakdownprobability = 0.5;

        public int BikeSpeedKmh { get; set; } = 130;
        public int BikeFuelTankLiters { get; set; } = 20;
        public int BikeKmPerLiter { get; set; } = 15;
        public double BikeBreakProb { get; set; } = 0.03;

        // Tesla Model-S
        public int TeslaSpeedKmh { get; set; } = 120;
        public int TeslaBatteryKwh { get; set; } = 700;
        public int TeslaUsageKwhPerHour { get; set; } = 20;
        public double TeslaBreakProbability { get; set; } = 0.01;
        public double Teslatimetorefuelhrs = 1;

        public int SubSpeedKmh { get; set; } = 160;

        // Virginia-Class Submarine
        public int Nuclearsubspeedknots = 35;
        public double SubBreakPobability { get; set; } = 0.04;

 

       
       

    }
}
