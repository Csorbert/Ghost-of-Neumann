using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface ICharacter
    {
        string Name { get;}
        int Level { get;}
        int Health { get;}
        int AttackPower { get; }
        int PhysicalDefense { get;}
        int MagicDefense { get;}
        int Kills { get;}
        int Death { get; }
        int Neukon { get;}

        void Attack(ICharacter target);
        void Defend(string type, int damage);
        void OnHit(int damage);
        void OnMove(string lenyomott);
    }

}
