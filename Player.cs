using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name; 
            Health = health;
            Console.WriteLine($"You have {health} health");
        
            
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Health = 0;
                Console.WriteLine($"You took {damage} damage and have died.");
            }
            else
            {
                Console.WriteLine($"You have taken {damage} damage.");
            }



        }
        public void PickUpItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"You have picked up {item}");

        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}