using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface IMagicItem
    {
        string Name { get; }
        int ManaCost { get; }
        string Type { get; }
        double Effective { get; }
        int Value { get; }
        bool Stackable { get; }

        void Use(ICharacter target);
        void Sell();
    }
}
