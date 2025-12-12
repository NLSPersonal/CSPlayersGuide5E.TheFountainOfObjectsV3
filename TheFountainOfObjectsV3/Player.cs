namespace TheFountainOfObjectsV3
{
    public class Player
    {
        // VARIABLES - 

        // PROPERTIES - 
        public Location Location { get; set; }

        public bool IsAlive { get; set; } = true;

        // CONSTRUCTORS -
        public Player()
        {
            Location = new Location(Cave.CaveEntrance);
        }

        // METHODS - 
        public void Sense(Cave cave)
        {
            if (Location.Equals(Cave.CaveEntrance))
            {
                Console.WriteLine("You see light coming from the cavern entrance.");
            }

            if (Location.Equals(Cave.FountainLocation) && cave.CaveRoom[Cave.FountainLocation.Row, Cave.FountainLocation.Column].Fountain.IsEnabled == false)
            {
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
            }

            if (Location.Equals(Cave.FountainLocation) && cave.CaveRoom[Cave.FountainLocation.Row, Cave.FountainLocation.Column].Fountain.IsEnabled)
            {
                Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            }

            List<CaveRoomType> adjacentCaveRoomTypes = cave.CaveRoom[Location.Row, Location.Column].GetAdjacentCaveRoomTypes(cave);
            foreach (CaveRoomType caveRoomType in adjacentCaveRoomTypes)
            {
                if (caveRoomType == CaveRoomType.Pit)
                {
                    Console.WriteLine("You feel a draft of air push into the room. A pit is nearby!");
                    break;
                }
            }

            if (cave.CaveRoom[Location.Row, Location.Column].CheckAdjacentCaveRoomsForMaelstroms(cave))
            {
                Console.WriteLine("You hear a low rumbling noise. A Maelstrom is close!");
            }

            if (cave.CaveRoom[Location.Row, Location.Column].CheckAdjacentCaveRoomsForAmaroks(cave))
            {
                Console.WriteLine("You smell rot and decay. An Amarok is close!");
            }
        }

        public void Decide(Cave cave)
        {
            bool isValid = false;
            while (isValid == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string userRequestedAction = Console.ReadLine();
                Console.ResetColor();
                switch (userRequestedAction.ToLower())
                {
                    case "move north":
                        Move("north", cave);
                        isValid = true;
                        break;

                    case "move east":
                        Move("east", cave);
                        isValid = true;
                        break;

                    case "move south":
                        Move("south", cave);
                        isValid = true;
                        break;

                    case "move west":
                        Move("west", cave);
                        isValid = true;
                        break;

                    case "enable fountain":
                        EnableFountain(cave);
                        isValid = true;
                        break;

                    default:
                        Console.WriteLine("This is not a valid action. Please try again.");
                        break;
                }
            }
        }

        // TO DO: Refactor to make player moves an enum.
        public void Move(string move, Cave cave)
        {
            switch (move)
            {
                case "north":
                    if (Location.Row < cave.AmountOfCaveRows - 1)
                    {
                        Location = Location with { Row = Location.Row + 1 };
                    }
                    else
                    {
                        Console.WriteLine("You run into a wall. You can't go any further North!");
                    }
                    break;


                case "east":
                    if (Location.Column < cave.AmountOfCaveColumns - 1)
                    {
                        Location = Location with { Column = Location.Column + 1 };
                    }
                    else
                    {
                        Console.WriteLine("You run into a wall. You can't go any further East!");
                    }
                    break;

                case "south":
                    if (Location.Row > 0)
                    {
                        Location = Location with { Row = Location.Row - 1 };
                    }
                    else
                    {
                        Console.WriteLine("You run into a wall. You can't go any further South!");
                    }
                    break;

                case "west":
                    if (Location.Column > 0)
                    {
                        Location = Location with { Column = Location.Column - 1 };
                    }
                    else
                    {
                        Console.WriteLine("You run into a wall. You can't go any further West!");
                    }
                    break;
            }
            // After moving, check if player has been transported by maelstrom.
            while (cave.CaveRoom[Location.Row, Location.Column].Maelstrom?.CheckIfAffectsPlayer(cave, this) == true)
            {
                cave.CaveRoom[Location.Row, Location.Column].Maelstrom.TeleportPlayer(cave, this);
            }

            if (cave.CaveRoom[Location.Row, Location.Column].Amarok?.CheckIfAffectsPlayer(cave, this) == true)
            {
                cave.CaveRoom[Location.Row, Location.Column].Amarok.KillPlayer(cave, this);
            }
        }

        public void EnableFountain(Cave cave)
        {
            if (Location.Equals(Cave.FountainLocation))
            {
                cave.CaveRoom[Cave.FountainLocation.Row, Cave.FountainLocation.Column].Fountain.IsEnabled = true;
            }
            else
            {
                Console.WriteLine("The fountain isn't in this room!");
            }
        }
    }
}
