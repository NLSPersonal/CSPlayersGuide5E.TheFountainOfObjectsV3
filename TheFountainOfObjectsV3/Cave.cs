namespace TheFountainOfObjectsV3
{
    public class Cave
    {
        // VARIABLES -

        // PROPERTIES -
        public int AmountOfCaveRows { get; }

        public int AmountOfCaveColumns { get; }

        public int AmountOfCaveRooms { get; }

        public CaveRoom[,] CaveRoom { get; }

        public CaveSize Size { get; }

        public static Location CaveEntrance { get; set; }

        public static Location FountainLocation { get; set; }

        public static List<Location>? PitLocations { get; set; }

        public static List<Location>? MaelstromLocations { get; set; }

        // CONSTRUCTORS - 
        public Cave(CaveSize caveSize)
        {
            if (caveSize == CaveSize.Small)
            {
                Size = CaveSize.Small;
                AmountOfCaveRows = 4;
                AmountOfCaveColumns = 4;
                AmountOfCaveRooms = AmountOfCaveRows * AmountOfCaveColumns;
                CaveRoom = new CaveRoom[AmountOfCaveRows, AmountOfCaveColumns];
                CaveEntrance = new Location(0,0);
                FountainLocation = new Location(0, 2);
                PitLocations = new List<Location> { new Location(2, 1)};
                MaelstromLocations = new List<Location> { new Location(1, 2) };

                for (int columnCounter = 0; columnCounter < AmountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < AmountOfCaveRows; rowCounter++)
                    {
                        CaveRoom[rowCounter, columnCounter] = new CaveRoom(rowCounter, columnCounter);
                    }
                }
            }

            if (caveSize == CaveSize.Medium)
            {
                Size = CaveSize.Medium;
                AmountOfCaveRows = 6;
                AmountOfCaveColumns = 6;
                AmountOfCaveRooms = AmountOfCaveRows * AmountOfCaveColumns;
                CaveRoom = new CaveRoom[AmountOfCaveRows, AmountOfCaveColumns];
                CaveEntrance = new Location(0, 0);
                FountainLocation = new Location(0, 2);
                PitLocations = new List<Location> { new Location(2, 2) };
                MaelstromLocations = new List<Location> { new Location(1, 1), new Location(0, 5), new Location(1, 0)};

                for (int columnCounter = 0; columnCounter < AmountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < AmountOfCaveRows; rowCounter++)
                    {
                        CaveRoom[rowCounter, columnCounter] = new CaveRoom(rowCounter, columnCounter);
                    }
                }
            }

            if (caveSize == CaveSize.Large)
            {
                Size = CaveSize.Large;
                AmountOfCaveRows = 8;
                AmountOfCaveColumns = 8;
                AmountOfCaveRooms = AmountOfCaveRows * AmountOfCaveColumns;
                CaveRoom = new CaveRoom[AmountOfCaveRows, AmountOfCaveColumns];
                CaveEntrance = new Location(0, 0);
                FountainLocation = new Location(0, 3);
                PitLocations = new List<Location> { new Location(2, 1) };
                MaelstromLocations = new List<Location> { new Location(1, 2) };

                for (int columnCounter = 0; columnCounter < AmountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < AmountOfCaveRows; rowCounter++)
                    {
                        CaveRoom[rowCounter, columnCounter] = new CaveRoom(rowCounter, columnCounter);
                    }
                }
            }
        }

        // METHODS - 

    }
}
