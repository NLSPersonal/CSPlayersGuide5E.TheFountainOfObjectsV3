using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjectsV3
{
    public class Creature
    {
        // VARIABLES -
        // PROPERTIES -
        protected Location Location { get; set; }

        // CONSTRUCTORS -

        // METHODS -
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
