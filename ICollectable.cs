using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface ICollectable
    {
        string Name { get; }
        int Value { get; }

        void Collect(ICharacter collector);
        void Interact(ICharacter user);
    }
}
