using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tank tank = new Tank(15);
            //tank.Info();

            //Console.Write("Введите объем топлива: ");
            //int amount = Convert.ToInt32(Console.ReadLine());
            //tank.Fill(amount);

            //tank.Info();

            //Engine engine = new Engine(10);
            //engine.Info();

            Car car = new Car(10, 40, 250);
            car.Info();
            car.Control();
        }
    }
}
