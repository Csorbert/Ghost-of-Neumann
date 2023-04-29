using System;
using System.Collections.Generic;
using System.IO;
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

        public int[] Player { get; private set; }

        public string[] Surroundings => throw new NotImplementedException();

        public string[] NPCs => throw new NotImplementedException();

        public string[] Enemies => throw new NotImplementedException();

        public string[] Items => throw new NotImplementedException();

        public string[] Interactables => throw new NotImplementedException();

        public Map(string txtname)
        {
            StreamReader r = new StreamReader(txtname, Encoding.UTF8);
            string filename = r.ReadLine().Split(';')[1];
            string mapname = r.ReadLine().Split(';')[1];
            string desc = r.ReadLine().Split(';')[1];
            string tp = r.ReadLine().Split(';')[1];
            string[,] ftp = new string[2, 2];
            int[] player = { 40, 12 };

            int permay = 0;
            foreach (var item in tp.Split('#'))
            {
                int x = 0;
                foreach (var item2 in item.Split(','))
                {
                    ftp[permay, x] = item2;
                    x++;
                }
            }

            string dest = r.ReadLine().Split(';')[1];
            string[,] storemap = new string[25, 80];

            for (int y = 0; y < 25; y++)
            {
                string sor = r.ReadLine();
                for (int x = 0; x < 80; x++)
                {
                    storemap[y, x] = sor[x].ToString();
                }
            }

            FileName = filename;
            MapName = mapname;
            Description = desc;
            Teleport = ftp;
            Destination = dest;
            StoreMap = storemap;
            Player = player;

            r.Close();
        }

        public Map()
        {
        }

        public void Move(char c)
        {
            switch (c) {
                case 'w':
                case 'W':
                    Player = new int[2] { Player[0], Player[1] - 1 };
                    break;
                case 'a':
                case 'A':
                    Player = new int[2] { Player[0] - 1, Player[1] };
                    break;
                case 'd':
                case 'D':
                    Player = new int[2] { Player[0] + 1, Player[1] };
                    break;
                case 's':
                case 'S':
                    Player = new int[2] { Player[0], Player[1] + 1 };
                    break;
                default:
                    break;
            }

            
            Console.Clear();
            DisplayMap();
        }

        public void DisplayMap()
        {
            for (int y = 0; y < 25; y++)
            {
                Console.WriteLine();
                for (int x = 0; x < 80; x++)
                {
                    if (x == Player[0] && y == Player[1])
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(StoreMap[y, x]);
                    }
                }
            }
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
