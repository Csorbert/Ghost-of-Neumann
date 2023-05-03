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

        public string[,] StoreMap { get; }

        public int[] Player { get; private set; }

        public string[] Surroundings => throw new NotImplementedException();

        public string[] NPCs => throw new NotImplementedException();

        public string[] Enemies => throw new NotImplementedException();

        public string[] Items => throw new NotImplementedException();

        public string[] Interactables => throw new NotImplementedException();


        public List<char> OOB { get; }


        public Map(string txtname, int xdata, int ydata)
        {
            Teleports = new Dictionary<string, List<string>>();
            Coords = new List<string>();
            OOB = new List<char> { '╔', '╗', '╝', '╚' , '╩' , '╣', '╠' , '║', '═' };


            StreamReader r = new StreamReader(txtname, Encoding.UTF8);
            string filename = r.ReadLine().Split(';')[1];
            string mapname = r.ReadLine().Split(';')[1];
            string desc = r.ReadLine().Split(';')[1];

            int[] player = { xdata, ydata };


            string[] dest = r.ReadLine().Split(';')[1].Split('|');
            List<string> mapnames = new List<string>();
            foreach (var destination in dest)
            {
                mapnames.Add(destination);
            }


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

            string coord = $"{Player[1]+1},{Player[0]+1}";

            if (Coords.Contains(coord))
            {
                foreach (var item in Teleports)
                {
                    if (item.Value.Contains(coord))
                    {
                        switch (Player[1])
                        {
                            case 0:
                                Program.current = new Map(item.Key, Player[0], 23);
                                break;
                            case 24:
                                Program.current = new Map(item.Key, Player[0], 1);
                                break;
                        }

                        switch (Player[0])
                        {
                            case 0:
                                Program.current = new Map(item.Key, 78, Player[1]);
                                break;
                            case 79:
                                Program.current = new Map(item.Key, 1, Player[1]);
                                break;
                        }

                        Console.Clear();
                        Program.current.DisplayMap();
                        break;
                    }
                }
            } else
            {
                OutOfBounds(original, modified);

                Console.Clear();
                DisplayMap();
            }
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
