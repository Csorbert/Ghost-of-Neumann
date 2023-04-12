using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    class Character : ICharacter
    {
        public string Name { get; }
        public int Level { get; }
        public int Health { get; set; }
        public int AttackPower { get; }
        public int PhysicalDefense { get; }
        public int MagicDefense { get; }
        public int Kills { get; }
        public int Death { get; }
        public int Neukon { get; }

        public void Attack(ICharacter target)
        {
            // implementation code
        }

        public void Defend(string type, int damage)
        {
            // implementation code
        }

        public void OnHit(int damage)
        {
            Health -= damage;
        }

        public void OnMove(string lenyomott)
        {
            // implementation code
        }

        public string Info()
        {
            return $"{Name}, {Level}, {Health}, {PhysicalDefense}, {MagicDefense}, {Kills}, {Death}, {Neukon}";
        }
    }
}
