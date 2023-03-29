using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface INonCollectable
    {
        string Name { get; set; }
        int Value { get; set; }

        // limitált (1) kollektálás
        void Collect(ICharacter collector);
        void Interact(ICharacter user);
    }
}
