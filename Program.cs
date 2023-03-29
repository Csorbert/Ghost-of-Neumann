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
            k1.Name = character[0];
            k1.Level = int.Parse(character[1]);
            k1.Health = int.Parse(character[2]);
            k1.PhysicalDefense = int.Parse(character[3]);
            k1.MagicDefense = int.Parse(character[4]);
            k1.Kills = int.Parse(character[5]);
            k1.Death = int.Parse(character[6]);
            k1.Neukon = int.Parse(character[7]);


            Console.WriteLine(k1.Info());


            Console.ReadKey();

        }
    }
}
