using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    class Program
    {
        static Statistics statsCounter = new Statistics();

        public static Map current;

        static void Main(string[] args)
        {

            current = new Map("aula.txt", 40, 12);

            Console.WriteLine("Press a button to start");

            while (true)
            {
                char c = Console.ReadKey().KeyChar;
                current.Move(c);

                statsCounter.StoreStatistics("step", 1);
                statsCounter.DisplayStats(statsCounter.NumberOfKills, statsCounter.ExperiencePoints, statsCounter.NumberOfStepsTaken, statsCounter.ItemsCollected);
            }

        }
    }
}
