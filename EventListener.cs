using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void CreateAlphabet()
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                alphabet.Add(c);
            }
        }

        public void QuickTimeAction()
        {
            // Create variables

            Random rnd = new Random();
            int timeToWait = rnd.Next(500, 1500);
            int timeReamining = timeToWait;
            char character = alphabet[rnd.Next(0, alphabet.Count-1)];

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
                if (character == task.Result.ToCharArray()[0])
                {
                    string message = $"Success";
                    Console.Write($"{message}{new string(' ', Console.WindowWidth - message.Length)}");
                } else
                {
                    string message = $"Fail";
                    Console.Write($"{message}{new string(' ', Console.WindowWidth - message.Length)}");
                }
            }
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

                Thread.Sleep(50);
                
                int timeRemaining = (int)Math.Max(0, timeToWait - stopwatch.ElapsedMilliseconds);
                Console.SetCursorPosition(0, 27);
                string message = $"Time left: {timeRemaining} milliseconds";
                Console.Write($"{message}{new string(' ', Console.WindowWidth - message.Length)}");
            }
            return null;
        }

    }
}
