using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    internal class Tank
    {
        static readonly int MIN_VOLUME = 20;
        static readonly int MAX_VOLUME = 120;

        readonly int Volume;
        double fuelLevel;
        public double FuelLevel
        {
            get => fuelLevel;
        }

        public Tank(int volume)
        {
            if (volume < MIN_VOLUME) volume = MIN_VOLUME;
            if (volume > MAX_VOLUME) volume = MAX_VOLUME;
            Volume = volume;

            fuelLevel = 0;
        }

        public void Fill(double amount)
        {
            if (amount < 0) return;
            if (fuelLevel + amount <= Volume) fuelLevel += amount;
            else fuelLevel = Volume;
        }

        public void Info()
        {
            Console.WriteLine($"Tank volume: {Volume}");
            Console.WriteLine($"Fuel level: {FuelLevel}");
        }
    }
}
