using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    internal class Engine
    {
        static readonly double MIN_CONSUMPTION = 3;
        static readonly double MAX_CONSUMPTION = 30;

        double consumption;
        double consumptionPerSecond;
        public bool Started {  get; private set; }
        public double Consumption
        {
            get => consumption;
            set
            {
                if (value < MIN_CONSUMPTION) value = MIN_CONSUMPTION;
                if (value > MAX_CONSUMPTION) value = MAX_CONSUMPTION;
                consumption = value;

                SetConsumptionPerSecond();
            }
        }
        public double ConsumptionPerSecond
        {
            get => consumptionPerSecond;
        }

        public Engine(double consumption) 
        {
            Consumption = consumption;
            Started = false;
        }

        void SetConsumptionPerSecond()
        {
            consumptionPerSecond = consumption * 3e-5;
        }

        public void Start() 
        {
            Started = true;
        }

        public void Stop() 
        {
            Started = false;
        }

        public void Info() 
        {
            Console.WriteLine($"Consumption per 100 km: {Consumption}");
            Console.WriteLine($"Consumption per 1 sec: {ConsumptionPerSecond}");
        }



    }
}
