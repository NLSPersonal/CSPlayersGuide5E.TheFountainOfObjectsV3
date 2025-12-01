using System.Collections.Generic;

namespace TheFountainOfObjectsV3
{
    public class Cave
    {
        // Variables -

        // Properties -
        public int AmountOfCaveRows { get; }

        public int AmountOfCaveColumns { get; }

        public int AmountOfCaveRooms { get; }

        public CaveRoom[,] CaveRoom { get; }

        public CaveSize Size { get; }

        public static Location CaveEntrance { get; set; }

        public static Location FountainLocation { get; set; }

        public static List<Location> PitLocations { get; set; }

        // Constructors - 
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

                // TO DO: Refactor to remove arrayCounter if not needed
                int arrayCounter = 0;
                for (int columnCounter = 0; columnCounter < AmountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < AmountOfCaveRows; rowCounter++, arrayCounter++)
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

                int arrayCounter = 0;
                for (int columnCounter = 0; columnCounter < AmountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < AmountOfCaveRows; rowCounter++, arrayCounter++)
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

                int arrayCounter = 0;
                for (int columnCounter = 0; columnCounter < AmountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < AmountOfCaveRows; rowCounter++, arrayCounter++)
                    {
                        CaveRoom[rowCounter, columnCounter] = new CaveRoom(rowCounter, columnCounter);
                    }
                }
            }
        }

        // Methods - 
    }
}
