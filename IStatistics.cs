using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface IStatistics
    {
        int NumberOfKills { get; }
        int ExperiencePoints { get; }
        int NumberOfStepsTaken { get; }
        int ItemsCollected { get; }

        int numberOfDeath { get; }

        bool IsGameFinished { get; }

        void StoreStatistics(string typeOfStatistics, int valuePipeLine);

        void DisplayStats(int kills, int experience, int steps, int itemsCollected, char o, int death=0);


    }
}
