using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    interface ICurrentMap
    {
        string MapName { get; set; }
        string Description { get; set; }
        string[] Surroundings { get; set; }
        string[] NPCs { get; set; }
        string[] Enemies { get; set; }
        string[] Items { get; set; }
        string[] Interactables { get; set; }

        void TeleportMap(ICurrentMap target);
        void OutOfBounds(ICurrentMap location);
        void DisplayMap(ICurrentMap map);
    }


        class EventListener
    {

        // Ide jönnek majd a listenerek

    }

    class Character : ICharacter
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int PhysicalDefense { get; set; }
        public int MagicDefense { get; set; }
        public int Kills { get; set; }
        public int Death { get; set; }
        public int Neukon { get; set; }

        public void Attack(ICharacter target)
        {
            // implementation code
        }

        public void Defend(int damage)
        {
            // implementation code
        }

        public void OnHit(int damage) {
            if (Health - damage <= 0)
            {
                Health = 0;
                Death++;
            } else
            {
                Health -= damage;
            }
        }

        public string Info()
        {
            return $"{Name}, {Level}, {Health}, {PhysicalDefense}, {MagicDefense}, {Kills}, {Death}, {Neukon}";
        }
    }
}
