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

        public Dictionary<string, List<string>> Teleports { get; }

        public List<string> Coords { get; }

        public List<string> QTACoords { get; }

        public string[,] StoreMap { get; }

        public int[] Player { get; private set; }

        public string[] Surroundings => throw new NotImplementedException();

        public string[] NPCs => throw new NotImplementedException();

        public string[] Enemies => throw new NotImplementedException();

        public string[] Items => throw new NotImplementedException();

        public string[] Interactables => throw new NotImplementedException();

        public int itemsPickedUp { get; private set; }

        public List<char> OOB { get; }


        public Map(string txtname, int xdata, int ydata)
        {
            Teleports = new Dictionary<string, List<string>>();
            Coords = new List<string>();
            QTACoords = new List<string>();
            OOB = new List<char> { '╔', '╗', '╝', '╚' , '╩' , '╣', '╠' , '║', '═' };

            // Start reading map

            StreamReader r = new StreamReader(txtname, Encoding.UTF8);
            string filename = r.ReadLine().Split(';')[1];
            string mapname = r.ReadLine().Split(';')[1];
            string desc = r.ReadLine().Split(';')[1];

            int[] player = { xdata, ydata };

            // Map names to teleport to

            string[] dest = r.ReadLine().Split(';')[1].Split('|');
            List<string> mapnames = new List<string>();
            foreach (var destination in dest)
            {
                mapnames.Add(destination);
            }

            // Store teleports coords accordingly

            string[] tp = r.ReadLine().Split(';')[1].Split('|');
            int mapnumber = 0;
            foreach (var teleport in tp)
            {
                List<string> ftp = new List<string>();
                string[] hashtagcoords = teleport.Split('#');
                foreach (var item in hashtagcoords)
                {
                    string[] modifieditem = item.Split(',');
                    if (item.Contains("-"))
                    {
                        string[] sorozat = modifieditem[1].Split('-');
                        for (int i = int.Parse(sorozat[0]); i <= int.Parse(sorozat[1]); i++)
                        {
                            string final = $"{modifieditem[0]},{i}";
                            ftp.Add(final);
                            Coords.Add(final);
                        }
                    } else
                    {
                        ftp.Add($"{modifieditem[0]},{modifieditem[1]}");
                        Coords.Add($"{modifieditem[0]},{modifieditem[1]}");
                    }
                }

                Teleports.Add(mapnames[mapnumber], ftp);
            }
            
            // Storing the map in matrix

            string[,] storemap = new string[25, 80];

            for (int y = 0; y < 25; y++)
            {
                string sor = r.ReadLine();
                for (int x = 0; x < 80; x++)
                {
                    storemap[y, x] = sor[x].ToString();
                }
            }

            // Random QTA

            Random rng = new Random();
            int qtax = rng.Next(0, 80);
            int qtay = rng.Next(0, 25);
            while (storemap[qtay,qtax] != " ")
            {
                qtax = rng.Next(0, 80);
                qtay = rng.Next(0, 25);
            }
            QTACoords.Add($"{qtay+1},{qtax+1}");
            storemap[qtay, qtax] = "╳";

       
            List<string> tCoords = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                int tx = rng.Next(0, 80);
                int ty = rng.Next(0, 25);

                while (storemap[ty, tx] != " ")
                {
                    tx = rng.Next(0, 80);
                    ty = rng.Next(0, 25);
                }

                tCoords.Add($"{ty + 1},{tx + 1}");
                storemap[ty, tx] = "T";
            }
            // Set values

            FileName = filename;
            MapName = mapname;
            Description = desc;
            StoreMap = storemap;
            Player = player;

            r.Close();
        }

        public Map()
        {

        }

        public void Move(char c)
        {
            string original = $"{Player[0]},{Player[1]}";

            // Move player

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

            string modified = $"{Player[0]},{Player[1]}";
            if (StoreMap[Player[1], Player[0]] == "T")
            {
                StoreMap[Player[1], Player[0]] = " ";
                itemsPickedUp++;
            }
            // If player coord is teleport

            string coord = $"{Player[1]+1},{Player[0]+1}";

            if (Coords.Contains(coord))
            {
                foreach (var item in Teleports)
                {
                    if (item.Value.Contains(coord))
                    {

                        // Decide where to place the player
                        int[] tocoord = new int[2];
                        switch (Player[1])
                        {
                            case 0:
                                tocoord = new int[] { Player[0], 23 };
                                break;
                            case 24:
                                tocoord = new int[] { Player[0], 1 };
                                break;
                        }
                        switch (Player[0])
                        {
                            case 0:
                                tocoord = new int[] { 78, Player[1] };
                                break;
                            case 79:
                                tocoord = new int[] { 1, Player[1] };
                                break;
                        }

                        if (Program.mapList.ContainsKey(item.Key))
                        {
                            // If map exists

                            Program.current = Program.mapList[item.Key];

                            modified = $"{tocoord[0]},{tocoord[1]}";

                            Program.current.Player[0] = tocoord[0];
                            Program.current.Player[1] = tocoord[1];
                        } else
                        {
                            // If map does not exist

                            Program.current = new Map(item.Key, tocoord[0], tocoord[1]);

                            Program.mapList.Add(item.Key, Program.current);

                            modified = $"{Program.current.Player[0]},{Program.current.Player[1]}";
                        }

                        Console.Clear();
                        Program.current.DisplayMap();
                        Program.current.Update(original, modified);

                        break;
                    }
                }
            } else if (QTACoords.Contains(coord))
            {
                Update(original, modified);

                Program.eventListener.QuickTimeAction();
            }
            else
            {
                // Check for OOB

                OutOfBounds(original, modified);

                // Update player pos

                modified = $"{Player[0]},{Player[1]}";

                Update(original, modified);
            }
        }

        public void DisplayMap()
        {
            Console.Clear();

            for (int y = 0; y < 25; y++)
            {
                Console.WriteLine();
                for (int x = 0; x < 80; x++)
                {
                    Console.Write(StoreMap[y, x]);
                }
            }
        }

        public void Update(string fromloc, string toloc)
        {
            string[] from = fromloc.Split(',');
            int[] fromnum = { int.Parse(from[0]), int.Parse(from[1]) };

            string[] to = toloc.Split(',');
            int[] tonum = { int.Parse(to[0]), int.Parse(to[1]) };

            Console.SetCursorPosition(tonum[0],tonum[1]+1);
            Console.Write("X");

            if (fromloc != toloc)
            {
                Console.SetCursorPosition(fromnum[0], fromnum[1] + 1);
                Console.Write(StoreMap[fromnum[1], fromnum[0]]);
            }

            Console.SetCursorPosition(0, 25);
        }

        public void OutOfBounds(string fromloc, string toloc)
        {
            string[] from = fromloc.Split(',');
            int[] fromnum = { int.Parse(from[0]), int.Parse(from[1]) };

            string[] to = toloc.Split(',');
            int[] tonum = { int.Parse(to[0]), int.Parse(to[1]) };

            if (OOB.Contains(char.Parse(StoreMap[tonum[1], tonum[0]])))
            {
                Player = new int[2] { fromnum[0], fromnum[1] };
            }
        }
    }
}
