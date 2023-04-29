using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface IStatistics
    {
        int numberOfKills { get; }
        int experiencePoints { get; }
        int numberOfStepsTaken { get; }
        int itemsCollected { get; }
        bool isGameFinished { get; }

        void StoreStatistics(string typeOfStatistics, int valuePipeLine);

        void DisplayStats(int kills, int experience, int steps, int itemsCollected);


    }
}
