namespace TheFountainOfObjectsV3
{
    public class Cave
    {
        // Variables

        // Properties
        public int AmountOfCaveRows { get; }

        public int AmountOfCaveColumns { get; }

        public int AmountOfCaveRooms { get; }

        public CaveRoom[,] CaveRoom { get; }

        public CaveSize Size { get; }

        public (int Row, int Column) CaveEntrance { get; }

        public (int Row, int Column) FountainLocation { get; }

        // Constructors
        public Cave(CaveSize CaveSize)
        {
            if (CaveSize == CaveSize.Small)
            {
                Size = CaveSize.Small;
                AmountOfCaveRows = 4;
                AmountOfCaveColumns = 4;
                AmountOfCaveRooms = AmountOfCaveRows * AmountOfCaveColumns;
                CaveRoom = new CaveRoom[AmountOfCaveRows, AmountOfCaveColumns];
                CaveEntrance = (0, 0);
                FountainLocation = (0, 1);

                int arrayCounter = 0;
                for (int columnCounter = 0; columnCounter < AmountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < AmountOfCaveRows; rowCounter++, arrayCounter++)
                    {
                        CaveRoom[rowCounter, columnCounter] = new CaveRoom(rowCounter, columnCounter, CaveEntrance, FountainLocation);
                    }
                }
            }

            if (CaveSize == CaveSize.Medium)
            {
                Size = CaveSize.Medium;
                AmountOfCaveRows = 6;
                AmountOfCaveColumns = 6;
                AmountOfCaveRooms = AmountOfCaveRows * AmountOfCaveColumns;
                CaveRoom = new CaveRoom[AmountOfCaveRows, AmountOfCaveColumns];
                CaveEntrance = (0, 0);
                FountainLocation = (0, 2);

                int arrayCounter = 0;
                for (int columnCounter = 0; columnCounter < AmountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < AmountOfCaveRows; rowCounter++, arrayCounter++)
                    {
                        CaveRoom[rowCounter, columnCounter] = new CaveRoom(rowCounter, columnCounter, CaveEntrance, FountainLocation);
                    }
                }
            }

            if (CaveSize == CaveSize.Large)
            {
                Size = CaveSize.Large;
                AmountOfCaveRows = 8;
                AmountOfCaveColumns = 8;
                AmountOfCaveRooms = AmountOfCaveRows * AmountOfCaveColumns;
                CaveRoom = new CaveRoom[AmountOfCaveRows, AmountOfCaveColumns];
                CaveEntrance = (0, 0);
                FountainLocation = (0, 3);

                int arrayCounter = 0;
                for (int columnCounter = 0; columnCounter < AmountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < AmountOfCaveRows; rowCounter++, arrayCounter++)
                    {
                        CaveRoom[rowCounter, columnCounter] = new CaveRoom(rowCounter, columnCounter, CaveEntrance, FountainLocation);
                    }
                }
            }
        }

        // Methods
    }
}
