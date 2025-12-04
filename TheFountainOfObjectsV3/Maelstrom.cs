using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsV3
{
    public class Maelstrom
    {
        // VARIABLES - 
        // PROPERTIES - 
        public Location Location { get; set; }

        // CONSTRUCTORS - 
        public Maelstrom(Location maelstromLocation)
        {
            Location = maelstromLocation;
        }
        // METHODS -
        // Check if player has been transported by maelstrom. If so, move player one space to the north and two spaces east, wrapping around the cave as needed.
        public void CheckIfPlayerHasBeenTransportedByMaelstrom(Cave cave, Player player)
        {
            while (cave.CaveRoom[player.Location.Row, player.Location.Column].Maelstrom != null)
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"You are in the room at (Row:{player.Location.Row}, Column:{player.Location.Column})");
                Console.WriteLine("A maelstrom has caught you! You are being transported to another location in the cave!");
                int newPlayerLocationRow = (player.Location.Row + 1 + cave.AmountOfCaveRows) % cave.AmountOfCaveRows;
                int newPlayerLocationColumn = (player.Location.Column + 2) % cave.AmountOfCaveColumns;
                player.Location = new Location(newPlayerLocationRow, newPlayerLocationColumn);
                Console.WriteLine($"You have been transported to the room at (Row:{player.Location.Row}, Column:{player.Location.Column})");
            }
        }
    }
}
