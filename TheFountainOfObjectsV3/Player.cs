namespace TheFountainOfObjectsV3
{
    public class Player
    {
        // Variables

        // Properties
        public CaveRoom CurrentCaveRoom {  get; set; }

        // Constructors
        public Player(Cave Cave)
        {
            CurrentCaveRoom = Cave.CaveRoom[Cave.CaveEntrance.Row, Cave.CaveEntrance.Column];
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

        public void Decide(Cave Cave)
        {
            bool isValid = false;
            while (isValid == false)
            {
                string userRequestedAction = Console.ReadLine();
                switch (userRequestedAction.ToLower())
                {
                    case "move north":
                        Move("north", Cave);
                        isValid = true;
                        break;

                    case "move east":
                        Move("east", Cave);
                        isValid = true;
                        break;

                    case "move south":
                        Move("south", Cave);
                        isValid = true;
                        break;

                    case "move west":
                        Move("west", Cave);
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

        public void Move(string Move, Cave Cave)
        {
            switch (Move)
            {
                case "north":
                    if (CurrentCaveRoom.CaveRoomLocation.Row < Cave.AmountOfCaveColumns - 1)
                    {
                        CurrentCaveRoom = Cave.CaveRoom[CurrentCaveRoom.CaveRoomLocation.Row + 1, CurrentCaveRoom.CaveRoomLocation.Column];
                    }
                    else
                    {
                        Console.WriteLine("You run into a wall. You can't go any further North!");
                    }
                    break;


                case "east":
                    if (CurrentCaveRoom.CaveRoomLocation.Column < Cave.AmountOfCaveRows - 1)
                    {
                        CurrentCaveRoom = Cave.CaveRoom[CurrentCaveRoom.CaveRoomLocation.Row, CurrentCaveRoom.CaveRoomLocation.Column + 1];
                    }
                    else
                    {
                        Console.WriteLine("You run into a wall. You can't go any further East!");
                    }
                    break;

                case "south":
                    if (CurrentCaveRoom.CaveRoomLocation.Row > 0)
                    {
                        CurrentCaveRoom = Cave.CaveRoom[CurrentCaveRoom.CaveRoomLocation.Row - 1, CurrentCaveRoom.CaveRoomLocation.Column];
                    }
                    else
                    {
                        Console.WriteLine("You run into a wall. You can't go any further South!");
                    }
                    break;

                case "west":
                    if (CurrentCaveRoom.CaveRoomLocation.Column > 0)
                    {
                        CurrentCaveRoom = Cave.CaveRoom[CurrentCaveRoom.CaveRoomLocation.Row, CurrentCaveRoom.CaveRoomLocation.Column - 1];
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
