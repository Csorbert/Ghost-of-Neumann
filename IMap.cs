﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface ICurrentMap
    {
        string FileName { get; }
        string MapName { get; }
        string Description { get; }
        Dictionary<string, List<string>> Teleports { get; }
        List<string> Coords { get; }
        string[,] StoreMap { get; }
        int[] Player { get; }
        string[] Surroundings { get; }
        string[] NPCs { get; }
        string[] Enemies { get; }
        string[] Items { get; }
        string[] Interactables { get; }

        List<char> OOB { get; }

        void Move(char c);
        void DisplayMap();
        void Update(string fromloc, string toloc);
        void OutOfBounds(string fromloc, string toloc);
    }
}
