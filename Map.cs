using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    class Map : ICurrentMap
    {
        public string FileName { get; }

        public string MapName { get; }

        public string Description { get; }

        public string[,] Teleport { get; }

        public string Destination { get; }

        public string[,] StoreMap { get; }

        public string[] Surroundings => throw new NotImplementedException();

        public string[] NPCs => throw new NotImplementedException();

        public string[] Enemies => throw new NotImplementedException();

        public string[] Items => throw new NotImplementedException();

        public string[] Interactables => throw new NotImplementedException();

        public void DisplayMap(ICurrentMap map)
        {
            throw new NotImplementedException();
        }

        public void OutOfBounds(ICurrentMap location)
        {
            throw new NotImplementedException();
        }

        public void TeleportMap(ICurrentMap target)
        {
            throw new NotImplementedException();
        }
    }
}
