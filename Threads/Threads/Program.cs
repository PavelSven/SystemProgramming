using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    internal class Program
    {
        static bool finish = false;
        static bool suspendPlus = false;
        static bool suspendMinus = false;

        static void Main(string[] args)
        {
            //Plus();
            //Minus();
            Thread plusThread = new Thread(Plus);
            Thread minusThread = new Thread(Minus);

            plusThread.Start();
            minusThread.Start();

            ConsoleKey key;
            Console.WriteLine("Press any key to stop");
        }

        static void Plus()
        {
            while (!finish)
            {
                Console.Write($"+ {Thread.CurrentThread.GetHashCode()}\t");
                Thread.Sleep(500);
            }
        }

        static void Minus()
        {
            while (!finish) 
            {
                Console.Write($"- {Thread.CurrentThread.GetHashCode()}\t");
                Thread.Sleep(500);
            }
        }
    }
}
