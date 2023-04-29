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

        static void Main(string[] args)
        {

            Map aula = new Map("aula.txt");


            Console.WriteLine("Press a button to start");

            while (true)
            {
                char c = Console.ReadKey().KeyChar;
                aula.Move(c);

                statsCounter.StoreStatistics("step", 1);
                statsCounter.DisplayStats(statsCounter.NumberOfKills, statsCounter.ExperiencePoints, statsCounter.NumberOfStepsTaken, statsCounter.ItemsCollected);
            }

        }
    }
}
