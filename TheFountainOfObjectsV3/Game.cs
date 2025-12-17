namespace TheFountainOfObjectsV3
{
    public class Game
    {
        // VARIABLES - 

        // PROPERTIES - 
        public Player Player1 { get; set; }

        public Cave Cave { get; set; }

        public bool GameHasBeenWon { get; set; }

        public bool GameHasBeenLost { get; set; }

        // CONSTRUCTORS - 

        // METHODS - 
        public void DisplaysRules()
        {
            //Console.ForegroundColor = ConsoleColor.Green;
            string gameRules = 
                "Welcome to the Fountain Of Objects game!\n\n" +

                "You find yourself in the mouth of a cave.\n" +
                "Light is visible only in the entrance, and no other light is seen anywhere in the caverns.\n" +
                "You must navigate the caverns with your other senses.\n" +
                "Your goal is to make it to the Fountain Of Objects that is deep within the cave, activate it, then escape via the entrance.\n\n" +

                "Look out for pits.\n" +
                "You will feel a breeze if a pit is in an adjacent room.\n" +
                "If you enter a room with a pit, you will die.\n\n" + 

                "Maelstroms are violent forces of sentient wind.\n" +
                "Entering a room with one could transport you to any other location in the caverns.\n" +
                "You will be able to hear their growling and groaning in nearby rooms.\n\n" + 

                "Amaroks roam the caverns.\n" +
                "Encountering one is certain death, but you can smell their rotten stench in nearby rooms\n\n" +

                "You carry with you a bow and a quiver of arrows.\n" +
                "You can use them to shoot monsters in the caverns but be warned: you have a limited supply.\n";

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
                Console.ForegroundColor = ConsoleColor.Green;
                string userRequestedCaveSize = Console.ReadLine();
                Console.ResetColor();
                switch (userRequestedCaveSize.ToLower())
                {
                    case "small":
                        Cave = new Cave(CaveSize.Small);
                        Player1 = new Player();
                        isValid = true;
                        break;

                    case "medium":
                        Cave = new Cave(CaveSize.Medium);
                        Player1 = new Player();
                        isValid = true;
                        break;

                    case "large":
                        Cave = new Cave(CaveSize.Large);
                        Player1 = new Player();
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
            while (GameHasBeenWon == false && GameHasBeenLost == false)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"You are in the room at (Row:{Player1.Location.Row}, Column:{Player1.Location.Column})");
                Player1.Sense(Cave);
                Console.WriteLine("What do you want to do?\n");
                Player1.Decide(Cave);
                CheckIfGameHasBeenWon(Cave, Player1);
                CheckIfGameHasBeenLost(Cave, Player1);
            }
        }

        // TO DO: Consider making a helper class to write console lines in a particular color to reduce code duplication.
        // TO DO: Consider making a helper class to display player location to reduce code duplication.
        public void CheckIfGameHasBeenWon(Cave cave, Player player)
        {
            if (cave.CaveRoom[Cave.FountainLocation.Row, Cave.FountainLocation.Column].Fountain.IsEnabled && (player.Location.Equals(Cave.CaveEntrance)))
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"You are in the room at (Row:{Player1.Location.Row}, Column:{Player1.Location.Column})");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
                Console.ResetColor();
                GameHasBeenWon = true;
            }
        }

        public void CheckIfGameHasBeenLost(Cave cave, Player player)
        {
            if (player.IsAlive == false)
            {
                GameHasBeenLost = true;
            }

            if (cave.CaveRoom[player.Location.Row, player.Location.Column].CaveRoomType == CaveRoomType.Pit)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"You are in the room at (Row:{Player1.Location.Row}, Column:{Player1.Location.Column})");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You feel the ground below your feet, and then suddenly you don't. You tumble down the pit. You are never seen again. Game over!");
                Console.ResetColor();
                GameHasBeenLost = true;
            }
        }

        public static void DisplayHelp() 
        {
            string commands = "The available commands are:\n\n" +
                "move north\n" +
                "move east\n" +
                "move south\n" +
                "move west\n" +
                "enable fountain\n" +
                "shoot north\n" +
                "shoot east\n" +
                "shoot south\n" +
                "shoot west\n" +
                "help\n";

            Console.WriteLine(commands);
        }
    }
}
