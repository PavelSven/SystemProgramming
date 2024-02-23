using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Car
{
    internal class Car
    {
        static readonly int MAX_SPEED_LOW_LIMIT = 100;
        static readonly int MAX_SPEED_HIGH_LIMIT = 400;
        public int MAX_SPEED {  get; }
        Engine engine;
        Tank tank;
        bool driverInside;
        struct Threads
        {
            public Thread PanelThread { get; set; }
        }
        Threads threads;

        public Car(double consumption, int volume, int maxSpeed = 250)
        {
            engine = new Engine(consumption);
            tank = new Tank(volume);
            driverInside = false;
            threads = new Threads();
            if (maxSpeed < MAX_SPEED_LOW_LIMIT) maxSpeed = MAX_SPEED_LOW_LIMIT;
            if (maxSpeed > MAX_SPEED_HIGH_LIMIT) maxSpeed = MAX_SPEED_HIGH_LIMIT;

            this.MAX_SPEED = maxSpeed;
        }

        public void GetIn()
        {
            driverInside = true;
            threads.PanelThread = new Thread(Panel);
            threads.PanelThread.Start();
        }

        public void GetOut() 
        {
            driverInside = false;
            threads.PanelThread.Join();
            Console.Clear();
            Console.WriteLine("You are out of the car");
        }

        public  void Control()
        {
            Console.WriteLine("Your car is ready, press Enter to get in");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;
                switch (key) 
                {
                    case ConsoleKey.Enter:
                        if (driverInside) GetOut();
                        else GetIn();
                        break;

                    case ConsoleKey.Escape:
                        GetOut();
                        break;

                    case ConsoleKey.F:
                        if (!driverInside)
                        {
                            Console.Write("Введите объем топлива: ");
                            double amount = Convert.ToInt32(Console.ReadLine());
                            tank.Fill(amount);
                        }
                        else
                        {
                            Console.WriteLine("Get out of the car");
                        }
                        break;
                }
            } while (key != ConsoleKey.Escape);
        }

        void Panel()
        {
            while (driverInside)
            {
                Console.Clear();
                Console.WriteLine($"Fuel level: {tank.FuelLevel} liters");
                Console.WriteLine($"Engine is {(engine.Started ? "started" : "stopped")}");
                Thread.Sleep(1000);
            }
        }

        public void Info()
        {
            engine.Info();
            tank.Info();
            Console.WriteLine($"Max speed: {MAX_SPEED}km/h");
        }
    }
}
