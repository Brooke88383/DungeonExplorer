using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        Random random = new Random();

        public Game()
        {
            // Initialize the game with one room and one player
            Console.WriteLine("What is your name");
            string users_name = Console.ReadLine();
            player = new Player($"{users_name}", 100);
            currentRoom = new Room("Start");

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop

            bool playing = true; 
            while (playing)
            {
                Console.WriteLine("What action would you like to do?");
                Console.WriteLine("inventory, Move to the next room or quit the game.");
                string NextAction = Console.ReadLine().ToLower();
                {
                    if (NextAction == "quit")
                    {
                        Console.WriteLine("Exiting... Thank you for playing.");
                        playing = false;
                    }
        
                    else if (NextAction == "inventory")
                    {
                        Console.WriteLine($"You have {player.InventoryContents()}");
                    }

                    else if (NextAction == "move")
                    {
                        Console.WriteLine("Moving to next room...");

                        //randomly chooses out of the 2 rooms

                        int RoomType = random.Next(1, 3);
                        if (RoomType == 1)
                        {
                            EnemyRoom enemyRoom = new EnemyRoom();
                            currentRoom = enemyRoom;
                            Console.WriteLine(enemyRoom.GetDescription());
                            enemyRoom.AttackPlayer(player);
                        }
                        else
                        {
                            ItemRoom itemRoom = new ItemRoom();
                            currentRoom = itemRoom; 
                            Console.WriteLine(itemRoom.GetDescription());
                            player.PickUpItem("Apple");
                        }
                    }
                    else Console.WriteLine("Invalid option please pick one of the three.");
                    

                }
            
        }
    }
    }
}
