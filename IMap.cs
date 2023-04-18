using System;
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
        string[,] Teleport { get; }
        string Destination { get; }
        string[,] StoreMap { get; }
        string[] Surroundings { get; }
        string[] NPCs { get; }
        string[] Enemies { get; }
        string[] Items { get; }
        string[] Interactables { get; }

        void TeleportMap(ICurrentMap target);
        void OutOfBounds(ICurrentMap location);
        void DisplayMap(ICurrentMap map);
    }
}
