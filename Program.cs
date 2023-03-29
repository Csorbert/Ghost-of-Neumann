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

            List<string> character = new List<string>();

            StreamReader r = new StreamReader("Character.txt", Encoding.UTF8);

            while (!r.EndOfStream)
            {
                character.Add(r.ReadLine().Split(';')[1]);
            }

            r.Close();

            Character k1 = new Character();


            Console.WriteLine(k1.Info());


            Console.ReadKey();

        }
    }
}
