using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
            
        }

        
        public abstract void Use();
    }

    public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon(string name, string description, int value, int damage)
            : base(name, description)
        {
            Damage = damage;
        }

        public override void Use()
        {
            Console.WriteLine($"You used the {Name}, dealing {Damage} damage! and killing the dragon");
        }
    }

    public class Potion : Item
    {
        public int HealAmount { get; set; }

        public Potion(string name, string description, int value, int healAmount)
            : base(name, description)
        {
            HealAmount = healAmount;
        }

        public override void Use()
        {
            Console.WriteLine($"You used the {Name}");
        }
    }

    
}
