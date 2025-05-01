using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using DungeonExplorer;

public class Player : Creature
{
    private List<Item> inventory = new List<Item>();

    
    public Player(int health, int attackStrength, string name)
        : base(health, attackStrength, name) 
    {
        Console.WriteLine($"You have {health} health.");
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
            
            Console.WriteLine($"You have {Health} health remaining.");
        }
    }

    public void PickUpItem(Item item)
    {
        inventory.Add(item);
        Console.WriteLine($"You have picked up {item.Name} - {item.Description}.");
    }

    public string InventoryContents()
    {
        return inventory.Count > 0
            ? string.Join(", ", inventory.Select(item => item.Name))
            : "Your inventory is empty.";
    }

    public Weapon EquippedWeapon { get; private set; }

    public void EquipWeapon(Weapon weapon)
    {
        EquippedWeapon = weapon;
        Console.WriteLine($"You equipped {weapon.Name}, which deals {weapon.Damage} damage!");
    }

    public bool HasItems()
    {
        return inventory.Count > 0;
    }

    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"You regain {amount} health. Your health is now {Health}.");
    }

    public void UseItem(string itemName)
    {
        var item = inventory.FirstOrDefault(currentitem => currentitem.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        if (item != null)
        {
            if (item is Potion potion) 
            {
                Heal(potion.HealAmount); 
            }

            item.Use(); 
            inventory.Remove(item); 
            Console.WriteLine($"The {item.Name} has been removed from your inventory.");
        }
        else
        {
            Console.WriteLine($"Item '{itemName}' not found in your inventory.");
        }
    }
}
