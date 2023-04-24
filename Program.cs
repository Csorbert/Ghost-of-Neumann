using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    class Program
    {
        static void Main(string[] args)
        {

            Map aula = new Map("aula.txt");

            Console.WriteLine("Press a button to start");

            while (true)
            {
                char c = Console.ReadKey().KeyChar;
                aula.Move(c);
            }

        }
    }
}
