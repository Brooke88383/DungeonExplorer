using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        List<Room> rooms = new List<Room>();

        public Room(string description)
        {
            this.description = description;


            
        }
        public void CreateRooms()
        {
        
            rooms.Add(new ItemRoom());
            rooms.Add(new EnemyRoom());

        }

        public string GetDescription()
        {
            return description;
        }
    }


    public class ItemRoom : Room
    {
        private List<string> inventory = new List<string>; 
        public ItemRoom(string inventory) : base("This room has an item.");
        {
            inventory.Add("Apple");
            Console.WriteLine("You have obtained an Apple.");
        }
    }

    public class EnemyRoom : Room
    {
        public EnemyRoom() : base("You were attacked. You lost 20 health.")
        {
            Console.WriteLine(GetDescription());

        }
        
        public void AttackPlayer(int damage)
        {
            int damage = 20; 
            player.TakeDamage(damage);
            
        }

        
    }
    
}