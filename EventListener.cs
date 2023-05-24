using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    public class EventListener
    {
        // Ide jönnek majd a listenerek

        List<char> alphabet = new List<char>();
        string[,] template = new string[25, 80];

        public static bool ActiveQTA;

        public void CreateQTA()
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                alphabet.Add(c);
            }

            StreamReader r = new StreamReader("quicktimeaction.txt", Encoding.UTF8);

            for (int y = 0; y < 25; y++)
            {
                string sor = r.ReadLine();
                for (int x = 0; x < 80; x++)
                {
                    template[y, x] = sor[x].ToString();
                }
            }

            r.Close();
        }
        public void QuickTimeAction()
        {
            // Create variables

            Random rnd = new Random();
            int timeToWait = rnd.Next(500, 1500);
            int timeReamining = timeToWait;
            char character = alphabet[rnd.Next(0, alphabet.Count-1)];

            ActiveQTA = true;
            Program.locked = true;

            // Display template

            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 80; x++)
                {
                    if (template[y, x] != " ")
                    {
                        Console.SetCursorPosition(x, y);
                        if (template[y, x] == "-")
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write(template[y, x]);
                        }
                    }
                }
            }

            Console.SetCursorPosition(40 - 1, 13 - 1);
            Console.Write(character.ToString().ToUpper());

            // Create async waiting task

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Task<string> task = Task.Run(() => WaitForInput(cancellationTokenSource.Token, timeReamining));
            if (task.Result != null && character == task.Result.ToLower().ToCharArray()[0])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string message = $"        S U C C E S S        ";
                Console.SetCursorPosition(25, 12);
                Console.Write(message);
                Program.statsCounter.NumberOfKills++;
                Program.statsCounter.ExperiencePoints +=40;
            } else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                string message = $"           F A I L           ";
                Console.SetCursorPosition(25, 12);
                Console.Write(message);
                Program.statsCounter.numberOfDeath++; //amint kész lesz a halál lehetősége
                cancellationTokenSource.Cancel();
            }


            cancellationTokenSource = new CancellationTokenSource();
            Task<string> idolopas = Task.Run(() => IdoLopo(cancellationTokenSource.Token, 1000));
            idolopas.Wait(1000);
            cancellationTokenSource.Cancel();


            Console.ForegroundColor = ConsoleColor.White;

            string coord = $"{Program.current.Player[0]},{Program.current.Player[1]}";
            Program.current.DisplayMap();
            Program.current.Update(coord, coord);

            ActiveQTA = false;
            Program.locked = false;
        }



        static string WaitForInput(CancellationToken cancellationToken, int timeToWait)
        {
            // Set starter bar progress

            Console.SetCursorPosition(25, 11);
            string display = "#############################";
            Console.Write(display);

            // Set a timer unrelated from runtime

            StringBuilder sb = new StringBuilder();
            Stopwatch stopwatch = Stopwatch.StartNew();

            while (!cancellationToken.IsCancellationRequested && stopwatch.ElapsedMilliseconds < timeToWait)
            {
                if (Console.KeyAvailable) // If console is still accessible
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    sb.Append(keyInfo.KeyChar);
                    return sb.ToString();
                }

                Thread.Sleep(3);

                // Bar percentage calculator

                int timeRemaining = (int)Math.Max(0, timeToWait - stopwatch.ElapsedMilliseconds);
                int percentage = (int)((float)timeRemaining / timeToWait * 100);

                switch (percentage)
                {
                    case int p when p >= 92:
                        display = "#############################"; break; // 29
                    case int p when p >= 85:
                        display = " ########################### "; break; // 27
                    case int p when p >= 78:
                        display = "  #########################  "; break; // 25
                    case int p when p >= 71:
                        display = "   #######################   "; break; // 23
                    case int p when p >= 65:
                        display = "    #####################    "; break; // 21
                    case int p when p >= 58:
                        display = "     ###################     "; break; // 19
                    case int p when p >= 52:
                        display = "      #################      "; break; // 17
                    case int p when p >= 45:
                        display = "       ###############       "; break; // 15
                    case int p when p >= 39:
                        display = "        #############        "; break; // 13
                    case int p when p >= 32:
                        display = "         ###########         "; break; // 11
                    case int p when p >= 26:
                        display = "          #########          "; break; // 9
                    case int p when p >= 19:
                        display = "           #######           "; break; // 7
                    case int p when p >= 13:
                        display = "            #####            "; break; // 5
                    case int p when p >= 6:
                        display = "             ###             "; break; // 3
                    case int p:
                        display = "              #              "; break; // 1
                }

                // Display bar progress

                Console.SetCursorPosition(25, 11);
                Console.Write(display);
                Console.SetCursorPosition(25, 13);
                Console.Write(display);
            }

            // Completely remove the bar

            Console.SetCursorPosition(25, 11);
            Console.Write("                             ");
            Console.SetCursorPosition(25, 13);
            Console.Write("                             ");

            return null;
        }



        static string IdoLopo(CancellationToken cancellationToken, int timeToWait)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (!cancellationToken.IsCancellationRequested && stopwatch.ElapsedMilliseconds < timeToWait)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true); // ellopjuk az inputot
                }
                Thread.Sleep(1);
            }
            return null;
        }
    }
}
