using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface ICharacter
    {
        string Name { get; set; }
        int Level { get; set; }
        int Health { get; set; }
        int AttackPower { get; set; }
        int PhysicalDefense { get; set; }
        int MagicDefense { get; set; }
        int Kills { get; set; }
        int Death { get; set; }
        int Neukon { get; set; }

        void Attack(ICharacter target);
        void Defend(string type, int damage);
        void OnHit(int damage);
        void OnMove(string lenyomott);
    }

}
