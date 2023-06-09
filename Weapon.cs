﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    class Weapon : IWeapon
    {
        public string Name { get; }

        enum  type{
            physical, magical
        }
        public string Type { get; }

        public int AttackPower { get; }

        public bool Repaired { get; set; }

        private int durability;
        
        public int Durability
        {
            get { return durability; }
            set
            {
                if(durability < 20 && !Repaired)
                {
                    Repair();
                    Repaired = true;
                }
                else
                {
                    durability = 0;
                }
            }
          
        }

        public void Attack(ICharacter target)
        {
            
        }

        public void Repair()
        {
            durability += 50; 
        }

        public void Use(ICharacter target)
        {
           
        }
        
    }
}
