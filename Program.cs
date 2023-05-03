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

            // Initial map load

            current = new Map("aula.txt", 40, 12);

            // Wait for press

            Console.WriteLine("Press Alt + Enter to avoid bugs!\n");
            Console.WriteLine("Press a button to start");
            Console.ReadKey();
            Console.Clear();

            // First map display and set player

            current.DisplayMap();
            string pos = $"{current.Player[0]},{current.Player[1]}";
            current.Update(pos, pos);

            statsCounter.StoreStatistics("step", 1);
            statsCounter.DisplayStats(statsCounter.NumberOfKills, statsCounter.ExperiencePoints, statsCounter.NumberOfStepsTaken, statsCounter.ItemsCollected);

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
