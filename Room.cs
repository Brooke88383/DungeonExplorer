using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using DungeonExplorer;

namespace DungeonExplorer
{
    public abstract class Room
    {
        private string description;

        public Room(string description)
        {
            this.description = description;
        }

        public virtual string GetDescription()
        {
            return description;
        }

        
        public abstract void Interact(Player player);
    }


    public static class ItemRandomiser
    {
        private static Random random = new Random();

        public static Item GetRandomItem()
        {
            List<Item> possibleItems = new List<Item>
        {
            HealingPotion,
            Sword
        };

            return possibleItems[random.Next(possibleItems.Count)];
        }

        public static Item HealingPotion = new Potion("Healing Potion", "Restores 50 health points", 30, 50);
        public static Item Sword = new Weapon("Sword", "A powerful blade dealing 100 damage", 100, 100);
    }


    public class ItemRoom : Room
    {
        private Item roomItem;

        public ItemRoom() : base("")
        {
            roomItem = ItemRandomiser.GetRandomItem(); 
        }

        public override void Interact(Player player)
        {
            Console.WriteLine(GetDescription());

            if (roomItem != null)
            {

                player.PickUpItem(roomItem);
            }
            else
            {
                Console.WriteLine("Room did not generate an item.");
            }
        }
    }

    public class EnemyRoom : Room
    {
        private Monster roomMonster;

        public EnemyRoom(Monster monster) : base("")
        {
            roomMonster = monster;
        }

        public override void Interact(Player player)
        {
            Console.WriteLine(GetDescription());
            Console.WriteLine($"A {roomMonster.Name} attacks! He has {roomMonster.Health} health remaining.");

            if (player.EquippedWeapon != null) 
            {
                int weaponDamage = player.EquippedWeapon.Damage;
                roomMonster.Health -= weaponDamage;
                Console.WriteLine($"You deal {weaponDamage} damage to the {roomMonster.Name}. It has {roomMonster.Health} health remaining.");
            }
            else
            {
                Console.WriteLine("You have no weapon equipped to attack with!");
            }

            roomMonster.PerformAttack(player);
        }




    }
}
        
    }
    
}
