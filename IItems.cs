using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface IItems
    {
        string Name { get; set; }
        string Type { get; set; }
        double Effective { get; set; }
        int Value { get; set; }
        bool Stackable { get; set; }

        void Use(ICharacter target);
        void Sell();
    }
}
