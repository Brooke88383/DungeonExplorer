using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        public int Health { get; set; }
        public int AttackStrength { get; set; }

        public string Name { get; set; }

        public Creature(int health, int attackstrength, string name)
        {
            Health = health;
            AttackStrength = attackstrength;
            Name = name;
        }
    }

    public class Monster : Creature
    {
        public string Type { get; set; }



        public Monster(int health, int attackstrength, string name, string type)
        : base(health, attackstrength, name)
        {
            Type = type;
        }

        public void PerformAttack(Player player)
        {
            Console.WriteLine($"{Name} attacks {player.Name}, dealing {AttackStrength} damage!");
            player.TakeDamage(AttackStrength); 
        }

        public static Monster Dragon = new Monster(50, 10, "Dragon", "Normal");
        public static Monster Giant = new Monster(100, 20, "Giant", "Boss");
    }
}

