using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class GameMap
    {
        private List<Room> rooms = new List<Room>();
        private Random random = new Random(); 

        public GameMap()
        {
            CreateRooms(); 
        }

        public Room GetRandomRoom()
        {
            return rooms[random.Next(rooms.Count)];
        }

        public void CreateRooms()
        {
            
            for (int i = 0; i < 2; i++) 
            {
                rooms.Add(new ItemRoom());
            }

            
            rooms.Add(new EnemyRoom(MonsterRandomiser.GetRandomMonster())); 
            rooms.Add(new EnemyRoom(MonsterRandomiser.GetRandomMonster()));
        }
    }

    public static class MonsterRandomiser
    {
        private static Random random = new Random();

        public static Monster GetRandomMonster()
        {
            List<Monster> possibleMonsters = new List<Monster>
            {
                Dragon,
                Giant
            };

            return possibleMonsters[random.Next(possibleMonsters.Count)];
        }

        public static Monster Dragon = new Monster(100, 20, "Dragon", "Normal");
        public static Monster Giant = new Monster(150, 25, "Giant", "Boss");
    }
}
