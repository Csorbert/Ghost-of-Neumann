using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacek_ikt
{
    class Attack
    {
        static void Main(ICharacter target, IItems physical, IMagicItem magic, IWeapon weapon)
        {
            DamageFactory damage = new DamageFactory();

            if (magic == null)
            {
                Damage physicalDamage = damage.CreateDamage(DamageType.Physical);
                physicalDamage.InflictDamage(target, weapon);
            } else
            {
                Damage magicalDamage = damage.CreateDamage(DamageType.Magical);
                magicalDamage.InflictDamage(target, weapon);
            }
        }
    }

    abstract class Damage
    {
        public abstract void InflictDamage(ICharacter target, IWeapon itemUsed);
    }

    enum DamageType
    {
        Physical,
        Magical
    }

    class DamageFactory
    {
        public Damage CreateDamage(DamageType type)
        {
            switch (type)
            {
                case DamageType.Physical:
                    return new PhysicalDamage();
                case DamageType.Magical:
                    return new MagicalDamage();
                default:
                    throw new ArgumentException("Error, idk");
            }
        }
    }

    class PhysicalDamage : Damage
    {
        public override void InflictDamage(ICharacter target, IWeapon itemUsed)
        {
            Console.WriteLine($"Megsebezted {target} a következőt használva: {itemUsed}");

            // valós számítások később megoldva

            target.OnHit(1);

            // egyéb kód ide
        }
    }

    class MagicalDamage : Damage
    {
        public override void InflictDamage(ICharacter target, IWeapon itemUsed)
        {
            Console.WriteLine($"Megsebezted {target} a következőt használva: {itemUsed}");

            // valós számítások később megoldva

            target.OnHit(1);

            // egyéb kód ide
        }
    }


}
