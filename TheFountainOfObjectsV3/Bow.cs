using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsV3
{
    public class Bow
    {
        // METHODS
        // Bow shoots an arrow in a direction based on what the player chose from the available commands.
        public void Shoot(Player player, Quiver playerQuiver, string targetDirection, Cave cave)
        {
            Location targetLocation = default;

            if (playerQuiver.ArrowCount > 0)
            {
                playerQuiver.ArrowCount--;

                Console.WriteLine($"You shoot an arrow to the {targetDirection}.");

                if (targetDirection == "north")
                {
                    if (player.Location.Row + 1 >= cave.AmountOfCaveRows)
                    {
                        Console.WriteLine("Your arrow hits a wall and falls to the ground.");
                        return;
                    }
                    targetLocation = cave.CaveRoom[player.Location.Row + 1, player.Location.Column].Location;
                }

                else if (targetDirection == "east")
                {
                    if (player.Location.Column + 1 >= cave.AmountOfCaveColumns)
                    {
                        Console.WriteLine("Your arrow hits a wall and falls to the ground.");
                        return;
                    }
                    targetLocation = cave.CaveRoom[player.Location.Row, player.Location.Column + 1].Location;
                }

                else if (targetDirection == "south")
                {
                    if (player.Location.Row - 1 < 0)
                    {
                        Console.WriteLine("Your arrow hits a wall and falls to the ground.");
                        return;
                    }
                    targetLocation = cave.CaveRoom[player.Location.Row - 1, player.Location.Column].Location;
                }

                else if (targetDirection == "west")
                {
                    if (player.Location.Column - 1 < 0)
                    {
                        Console.WriteLine("Your arrow hits a wall and falls to the ground.");
                        return;
                    }
                    targetLocation = cave.CaveRoom[player.Location.Row, player.Location.Column - 1].Location;
                }

                // Check for Maelstrom
                if (cave.CaveRoom[targetLocation.Row, targetLocation.Column].Maelstrom != null)
                {
                    cave.CaveRoom[targetLocation.Row, targetLocation.Column].Maelstrom = null;
                    Console.WriteLine("You hear a howl as the Maelstrom is struck down!");
                }

                // Check for Amarok
                else if (cave.CaveRoom[targetLocation.Row, targetLocation.Column].Amarok != null)
                {
                    cave.CaveRoom[targetLocation.Row, targetLocation.Column].Amarok = null;
                    Console.WriteLine("You hear a whimper as the Amarok is struck down!");
                }
                else
                {
                    Console.WriteLine("Your arrow flies true, but hits nothing.");
                }
            }

            else
            {
                Console.WriteLine("You have no arrows left to shoot!");
            }
        }
    }
}
