using System;
using System.Media;
using Microsoft.Win32;
using static DungeonExplorer.GameMap;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        Random random = new Random();
        

        public Game()
        {
            
            Console.WriteLine("What is your name");
            string users_name = Console.ReadLine();
            player = new Player(100, 10, $"{users_name}");
            
            


        }
        public void Start()
        {
            bool playing = true;

            while (playing)
            {
                Console.WriteLine("What action would you like to do?");
                Console.WriteLine("Type 'inventory', 'move', or 'quit':");
                string nextAction = Console.ReadLine().ToLower();

                if (nextAction == "quit")
                {
                    Console.WriteLine("Exiting... Thank you for playing.");
                    playing = false;
                }
                else if (nextAction == "inventory")
                {
                    Console.WriteLine($"Inventory: {player.InventoryContents()}");
                    if (!player.HasItems()) 
                    {
                        Console.WriteLine("Your inventory is empty.");
                    }
                    else
                    {
                        Console.WriteLine("Would you like to use an item? Type the item name or 'back' to return:");
                        string itemName = Console.ReadLine();

                        if (!string.IsNullOrEmpty(itemName) && itemName.ToLower() != "back")
                        {
                            player.UseItem(itemName);
                            

                        }
                        else
                        {
                            Console.WriteLine("Leaving inventory.");
                        }
                    }



                }
                else if (nextAction == "move")
                {
                    Console.WriteLine("Moving to the next room...");

                    
                    int roomType = random.Next(1, 3);
                    if (roomType == 1)
                    {
                        currentRoom = new EnemyRoom(Monster.Dragon); 
                    }
                    else
                    {
                        currentRoom = new ItemRoom();
                    }

                    Console.WriteLine(currentRoom.GetDescription());
                    currentRoom.Interact(player); 
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose one of the three options.");
                }

                
                if (player.Health <= 0)
                {
                    Console.WriteLine("You have been defeated. Game Over.");
                    playing = false;
                }
            }
        }
    }
}


