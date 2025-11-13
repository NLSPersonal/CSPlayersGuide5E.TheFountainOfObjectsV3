namespace TheFountainOfObjectsV3
{
    public class Game
    {
        // Variables

        // Properties
        public Player Player1 { get; set; }

        public Cave Cave { get; set; }

        public bool GameHasBeenWon { get; set; }

        public bool GameHasBeenLost { get; set; }

        // Constructors

        // Methods
        public void DisplaysRules()
        {
            //Console.ForegroundColor = ConsoleColor.Green;
            string gameRules = "Welcome to the Fountain Of Objects game!\n" +
                "You find yourself at the mouth of a cave. Your goal is to make it to the Fountain Of Objects that is deep within the cave.\n" +
                "To that end, you can move through the cave by typing in commands. The commands are:\n\n" +
                "move north\n" +
                "move east\n" +
                "move south\n" +
                "move west\n" +
                "enable fountain\n\n" +
                "As you move through the cavern you will use your sight, hearing, and smell to determine your next move.\n";

            Console.WriteLine(gameRules);
        }

        public void ChooseCaveSize()
        {
            Console.WriteLine("First, what size game would you like to play?\n\n" +
                "\"small\": 4x4 cave\n" +
                "\"medium\": 6x6 cave\n" +
                "\"large\": 8x8 cave\n");

            bool isValid = false;
            while (isValid == false)
            {
                string userRequestedCaveSize = Console.ReadLine();
                switch (userRequestedCaveSize.ToLower())
                {
                    case "small":
                        Cave = new Cave(CaveSize.Small);
                        Player1 = new Player(Cave);
                        isValid = true;
                        break;

                    case "medium":
                        Cave = new Cave(CaveSize.Medium);
                        Player1 = new Player(Cave);
                        isValid = true;
                        break;

                    case "large":
                        Cave = new Cave(CaveSize.Large);
                        Player1 = new Player(Cave);
                        isValid = true;
                        break;

                    default:
                        Console.WriteLine("That is not a valid cave size choice. Please try again.\n");
                        break;
                }
            }
        }

        public void Run()
        {
            while (GameHasBeenWon == false)
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"You are in the room at (Row:{Player1.CurrentCaveRoom.CaveRoomLocation.Row}, Column:{Player1.CurrentCaveRoom.CaveRoomLocation.Column})");
                Player1.Sense();
                Console.WriteLine("What do you want to do?");
                Player1.Decide(Cave);
                CheckIfGameHasBeenWon(Cave, Player1);
            }
        }

        public void CheckIfGameHasBeenWon(Cave Cave, Player Player)
        {
            if ((Cave.CaveRoom[Cave.FountainLocation.Row, Cave.FountainLocation.Column].Fountain.IsEnabled == true) && (Player.CurrentCaveRoom == Cave.CaveRoom[Cave.CaveEntrance.Row, Cave.CaveEntrance.Column]))
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"You are in the room at (Row:{Player1.CurrentCaveRoom.CaveRoomLocation.Row}, Column:{Player1.CurrentCaveRoom.CaveRoomLocation.Column})");
                Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
                GameHasBeenWon = true;
            }
        }
    }
}

