using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    class Statistics : IStatistics
    {
        private int numberOfKills;
        private int experiencePoints;
        private int numberOfStepsTaken;
        private int itemsCollected;
        private bool isGameFinished;

        int IStatistics.numberOfKills { get; }

        int IStatistics.experiencePoints { get; }

        int IStatistics.numberOfStepsTaken { get; }

        int IStatistics.itemsCollected { get; }

        bool IStatistics.isGameFinished { get; }


        public int NumberOfKills
        {
            get { return numberOfKills; }
            private set { numberOfKills = value; }
        }

        public int ExperiencePoints
        {
            get { return experiencePoints; }
            private set { experiencePoints = value; }
        }

        public int NumberOfStepsTaken
        {
            get { return numberOfStepsTaken; }
            private set { numberOfStepsTaken = value; }
        }

        public int ItemsCollected
        {
            get { return itemsCollected; }
            private set { itemsCollected = value; }
        }

        public bool IsGameFinished
        {
            get { return isGameFinished; }
            private set { isGameFinished = value; }


        }

        

        public void StoreStatistics(string typeOfStatistics, int valuePipeLine)
        {
            switch (typeOfStatistics)
            {
                case "kill":
                    numberOfKills += 1;
                    break;
                case "xp":
                    experiencePoints += valuePipeLine;
                    break;
                case "step":
                    numberOfStepsTaken += 1;
                    break;
                case "collect":
                    itemsCollected += 1;
                    break;

                default:
                    Console.WriteLine($"Invalid type of statistics: {typeOfStatistics}");
                    break;
            }
        }

        public void DisplayStats(int kills, int experience, int steps, int itemsCollected)
        {
            Console.WriteLine("Statistics:");
            Console.WriteLine($"Number of kills: {kills}");
            Console.WriteLine($"Experience points: {experience}");
            Console.WriteLine($"Number of steps taken: {steps}");
            Console.WriteLine($"Items collected: {itemsCollected}");
        }

        public Statistics()
        {
            NumberOfKills = 0;
            experiencePoints = 0;
            numberOfStepsTaken = 0;
            ItemsCollected = 0;
        }

    }
}
