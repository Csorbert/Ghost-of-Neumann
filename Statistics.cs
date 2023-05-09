using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    class Statistics : IStatistics
    {


        public int NumberOfKills { get; set; }

        public int ExperiencePoints { get; set; }

        public int NumberOfStepsTaken { get; set; }


        public int ItemsCollected { get; set; }

        public bool IsGameFinished { get; set; }

        public int numberOfDeath { get; set; }

        public void StoreStatistics(string typeOfStatistics, int valuePipeLine)
        {
            switch (typeOfStatistics)
            {
                case "kill":
                    NumberOfKills += 1;
                    break;
                case "xp":
                    ExperiencePoints += valuePipeLine;
                    break;
                case "step":
                    NumberOfStepsTaken += 1;
                    break;
                case "collect":
                    ItemsCollected += 1;
                    break;
                case "death":
                    numberOfDeath++;
                    break;

                default:
                    Console.WriteLine($"Invalid type of statistics: {typeOfStatistics}");
                    break;
            }
        }

        public void DisplayStats(int kills, int experience, int steps, int itemsCollected, int death)
        {
            Console.WriteLine("\nStatistics:");
            Console.WriteLine($"Number of kills: {kills}");
            Console.WriteLine($"Experience points: {experience}");
            Console.WriteLine($"Number of steps taken: {steps}");
            Console.WriteLine($"Items collected: {itemsCollected}");
            Console.WriteLine($"Number Of Deaths: {death}");
        }

        public Statistics()
        {
            NumberOfKills = 0;
            ExperiencePoints = 0;
            NumberOfStepsTaken = 0;
            ItemsCollected = 0;
        }

    }
}
