﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        bool isStatisticsOpen = false;
        bool isInventoryOpen = false;

        public void StoreStatistics(string typeOfStatistics, int valuePipeLine)
        {
            switch (typeOfStatistics)
            {
                case "kill":
                    NumberOfKills += valuePipeLine;
                    break;
                case "xp":
                    ExperiencePoints += valuePipeLine;
                    break;
                case "step":
                    NumberOfStepsTaken += valuePipeLine;
                    break;
                case "death":
                    numberOfDeath++;
                    break;

                default:
                    Console.WriteLine($"Invalid type of statistics: {typeOfStatistics}");
                    break;
            }
        }

        public void DisplayStats(int kills, int experience, int steps, int itemsCollected, char o , int death = 0)
        {
            switch (o){
                case 'P':
                case 'p':
                    if (!isStatisticsOpen && !isInventoryOpen)
                    {
                        Console.Clear();
                        Console.WriteLine("################|Press P to continue|################");
                        Console.WriteLine("\nStatistics:");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Number of kills: {kills}");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Experience points: {experience}");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Number of steps taken: {steps}");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Items collected: {itemsCollected}");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Number Of Deaths: {death}");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("#####################################################");
                        isStatisticsOpen = true;
                        Program.locked = true;
                    }
                    else if (isStatisticsOpen)
                    {
                        string coord = $"{Program.current.Player[0]},{Program.current.Player[1]}";
                        Program.current.DisplayMap();
                        Program.current.Update(coord, coord);
                        isStatisticsOpen = false;
                        Program.locked = false;
                    }

                    break;
                default:
                    
                    break;
            }
            
        }
        public void DisplayInventory(char a)
        {
            switch (a)
            {
                case 'I':
                case 'i':
                    if (!isInventoryOpen && !isStatisticsOpen)
                    {
                        Console.Clear();
                        Console.WriteLine("################|Press I to continue|################");
                        Console.WriteLine("\nInventory:");
                        Console.WriteLine(Environment.NewLine);
                        string[] lines = File.ReadAllLines("megszerezve.txt", Encoding.Default);
                        
                        foreach (var item in lines)
                        {
                            string [] sor = item.Split(';');
                            Console.WriteLine(sor[0]);
                            Console.WriteLine(Environment.NewLine);
                        }

                        Console.WriteLine("#####################################################");
                        isInventoryOpen= true;
                        Program.locked = true;
                    }
                    else if (isInventoryOpen)
                    {
                        string coord = $"{Program.current.Player[0]},{Program.current.Player[1]}";
                        Program.current.DisplayMap();
                        Program.current.Update(coord, coord);
                        isInventoryOpen = false;
                        Program.locked = false;
                    }

                    break;
                default:

                    break;
            }
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
