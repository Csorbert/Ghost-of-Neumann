using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    class Item : IItems
    {
        public string Name { get; }



        public string Type { get; }

        public double Effective { get; }

        public int Value {get ;}

        public bool Stackable { get; }

        public int Darab { get; }

        
        public void Sell(int cost)
        {
            if (Stackable)
            {
                cost = Darab * Value;
            }
            else
            {
                cost = Value;
            }
        }

        public void Use(ICharacter target)
        {
            //idk
        }

      
    }
}
