using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsV3
{
    public class Amarok : Creature
    {
        // VARIABLES -
        
        // PROPERTIES -
        // CONSTRUCTORS -
        public Amarok(Location amarokLocation)
        {
            Location = amarokLocation;
        }
        // METHODS -
        public void KillPlayer(Cave cave, Player player)
        {
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine($"You are in the room at (Row:{player.Location.Row}, Column:{player.Location.Column})");
            Console.WriteLine("An Amarok has attacked you! You were unable to best it. You are never seen again.");
            player.IsAlive = false;
        }
    }
}
