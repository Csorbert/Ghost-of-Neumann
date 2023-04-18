using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface IItems
    {
        string Name { get; }
        string Type { get; }
        double Effective { get; }
        int Value { get; }
        bool Stackable { get; }

        int Darab { get; }

        void Use(ICharacter target);
        void Sell(int cost);
    }
}
