using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsV3
{
    public class Creature
    {
        // PROPERTIES
        protected Location Location { get; set; }

        // METHODS
        // Check if the creature affects the player based on if they have the same location.
        public bool CheckIfAffectsPlayer(Cave cave, Player player)
        {
            if (player.Location.Equals(Location))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
