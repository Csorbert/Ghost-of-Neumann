using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface IWeapon
    {

        string Name { get; }
        string Type { get; }
        int AttackPower { get; }
        int Durability { get; set; }

        void Attack(ICharacter target);
        void Repair();
        void Use(ICharacter target);
    }
}
