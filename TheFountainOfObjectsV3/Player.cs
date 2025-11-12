namespace TheFountainOfObjectsV3
{
    public class Player
    {
        // Variables
        private CaveRoom _currentCaveRoom;

        // Properties
        public CaveRoom CurrentCaveRoom
        {
            get { return _currentCaveRoom; }
            set { _currentCaveRoom = value; }
        }

        // Constructors
        public Player(Cave passedCave)
        {
            _currentCaveRoom = passedCave.CaveRoom[passedCave.CaveEntrance.Row, passedCave.CaveEntrance.Column];
        }

        // Methods
        public void Sense()
        {
            if (CurrentCaveRoom.CaveRoomType == CaveRoomType.Entrance)
            {
                Console.WriteLine("You see light coming from the cavern entrance.");
            }

            if (CurrentCaveRoom.CaveRoomType == CaveRoomType.DisabledFountain)
            {
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
            }
            if (CurrentCaveRoom.CaveRoomType == CaveRoomType.EnabledFountain)
            {
                Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            }
        }

        public void Decide(Cave passedCave)
        {
            bool isValid = false;
            while (isValid == false)
            {
                string userRequestedAction = Console.ReadLine();
                switch (userRequestedAction.ToLower())
                {
                    case "move north":
                        Move("north", passedCave);
                        isValid = true;
                        break;

                    case "move east":
                        Move("east", passedCave);
                        isValid = true;
                        break;

                    case "move south":
                        Move("south", passedCave);
                        isValid = true;
                        break;

                    case "move west":
                        Move("west", passedCave);
                        isValid = true;
                        break;

                    case "enable fountain":
                        EnableFountain();
                        isValid = true;
                        break;

                    default:
                        Console.WriteLine("This is not a valid action. Please try again.");
                        break;
                }
            }
        }

        public void Move(string passedMove, Cave passedCave)
        {
            switch (passedMove)
            {
                case "north":
                    if (CurrentCaveRoom.CaveRoomLocation.Row < passedCave.AmountOfCaveColumns - 1)
                    {
                        _currentCaveRoom = passedCave.CaveRoom[CurrentCaveRoom.CaveRoomLocation.Row + 1, CurrentCaveRoom.CaveRoomLocation.Column];
                    }
                    else
                    {
                        Console.WriteLine("You run into a wall. You can't go any further North!");
                    }
                    break;


                case "east":
                    if (CurrentCaveRoom.CaveRoomLocation.Column < passedCave.AmountOfCaveRows - 1)
                    {
                        _currentCaveRoom = passedCave.CaveRoom[CurrentCaveRoom.CaveRoomLocation.Row, CurrentCaveRoom.CaveRoomLocation.Column + 1];
                    }
                    else
                    {
                        Console.WriteLine("You run into a wall. You can't go any further East!");
                    }
                    break;

                case "south":
                    if (CurrentCaveRoom.CaveRoomLocation.Row > 0)
                    {
                        _currentCaveRoom = passedCave.CaveRoom[CurrentCaveRoom.CaveRoomLocation.Row - 1, CurrentCaveRoom.CaveRoomLocation.Column];
                    }
                    else
                    {
                        Console.WriteLine("You run into a wall. You can't go any further South!");
                    }
                    break;

                case "west":
                    if (CurrentCaveRoom.CaveRoomLocation.Column > 0)
                    {
                        _currentCaveRoom = passedCave.CaveRoom[CurrentCaveRoom.CaveRoomLocation.Row, CurrentCaveRoom.CaveRoomLocation.Column - 1];
                    }
                    else
                    {
                        Console.WriteLine("You run into a wall. You can't go any further West!");
                    }
                    break;
            }
        }

        public void EnableFountain()
        {
            if (CurrentCaveRoom.Fountain != null)
            {
                CurrentCaveRoom.Fountain.IsEnabled = true;
                CurrentCaveRoom.CaveRoomType = CaveRoomType.EnabledFountain;
            }
            else
            {
                Console.WriteLine("The fountain isn't in this room!");
            }
        }
    }
}
