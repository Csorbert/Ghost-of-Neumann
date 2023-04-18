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

            StreamReader r = new StreamReader("aula.txt", Encoding.UTF8);
            string filename = r.ReadLine().Split(';')[1];
            string mapname = r.ReadLine().Split(';')[1];
            string desc = r.ReadLine().Split(';')[1];
            string tp = r.ReadLine().Split(';')[1];
            string dest = r.ReadLine().Split(';')[1];
            string[,] storemap = new string[25,80];

            for (int y = 0; y < 25; y++)
            {
                string sor = r.ReadLine();
                Console.WriteLine(sor);
                for (int x = 0; x < 80; x++)
                {
                    storemap[x, y] = sor[x].ToString();
                }
            }

            r.Close();

            for (int y = 0; y < 25; y++)
            {
                Console.WriteLine();
                for (int x = 0; x < 80; x++)
                {
                    Console.Write(storemap[x,y]);
                }
            }

            r.ReadLine();

        }
    }
}
