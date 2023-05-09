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

            Console.SetCursorPosition(0, 25);

            Console.WriteLine("\nPress: " + character);

            // Create async waiting task

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Task<string> task = Task.Run(() => WaitForInput(cancellationTokenSource.Token, timeReamining));
            if (!task.Wait(timeToWait)) // Ran out of time
            {
                string message = $"Fail";
                Console.Write($"{message}{new string(' ', Console.WindowWidth - message.Length)}");
                cancellationTokenSource.Cancel();
            }
            else  // Pressed something in time
            {
                if (character == task.Result.ToLower().ToCharArray()[0])
                {
                    string message = $"Success";
                    Console.Write($"{message}{new string(' ', Console.WindowWidth - message.Length)}");
                } else
                {
                    string message = $"Fail";
                    Console.Write($"{message}{new string(' ', Console.WindowWidth - message.Length)}");
                }
            }
            Thread.Sleep(1000);

            string coord = $"{Program.current.Player[0]},{Program.current.Player[1]}";
            Program.current.DisplayMap();
            Program.current.Update(coord, coord);
        }

        static string WaitForInput(CancellationToken cancellationToken, int timeToWait)
        {
            // CSIRIBÚ CSIRIBÁ

            StringBuilder sb = new StringBuilder();
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (!cancellationToken.IsCancellationRequested && stopwatch.ElapsedMilliseconds < timeToWait)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    sb.Append(keyInfo.KeyChar);
                    return sb.ToString();
                }

                Thread.Sleep(1);
                
                int timeRemaining = (int)Math.Max(0, timeToWait - stopwatch.ElapsedMilliseconds);
                Console.SetCursorPosition(0, 27);
                string message = $"Time left: {timeRemaining} milliseconds";
                Console.Write($"{message}{new string(' ', Console.WindowWidth - message.Length)}");
            }
            return null;
        }

    }
}
