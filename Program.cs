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
        public static Statistics statsCounter = new Statistics();

        public static Map current;

        public static EventListener eventListener = new EventListener();

        public static Dictionary<string, Map> mapList = new Dictionary<string, Map>();

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            // Initial map load

            current = new Map("aula.txt", 40, 12);

            mapList.Add(current.FileName, current);

            //megszerezve.txt clear 
            StreamWriter sw = new StreamWriter("megszerezve.txt");
            sw.Write("");
            sw.Close();

            // Initial QTA load

            EventListener.ActiveQTA = false;
            eventListener.CreateQTA();

            // Wait for press

            Console.WriteLine("Press Alt + Enter (or full screen) to avoid bugs!");
            Console.WriteLine("\nControls:");
            Console.WriteLine("\tMovement - W A S D ");
            Console.WriteLine("\tStatistics - P ");
            Console.WriteLine("\tInventory - I ");
            Console.Write("\nPress a button to start ");
            Console.ReadKey();
            Console.Clear();

            Console.CursorVisible = false;

            // First map display and set player

            current.DisplayMap();
            string pos = $"{current.Player[0]},{current.Player[1]}";
            current.Update(pos, pos);

             statsCounter.StoreStatistics("step", 1);
             //statsCounter.DisplayStats(statsCounter.NumberOfKills, statsCounter.ExperiencePoints, statsCounter.NumberOfStepsTaken, statsCounter.ItemsCollected);

            // Console.WriteLine(current.QTACoords);

            while (true)
            {
                char c = Console.ReadKey(true).KeyChar;

                current.Move(c);

                statsCounter.DisplayStats(statsCounter.NumberOfKills, statsCounter.ExperiencePoints, statsCounter.NumberOfStepsTaken, statsCounter.ItemsCollected, c);
                statsCounter.DisplayInventory(c);
            }

        }
    }
}
