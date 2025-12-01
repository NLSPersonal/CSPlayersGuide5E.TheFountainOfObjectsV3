namespace TheFountainOfObjectsV3
{
    public class CaveRoom
    {
        // Variables -

        // Properties -
        public Location Location { get; set; }

        public CaveRoomType CaveRoomType { get; set; }

        public Fountain? Fountain { get; set; }

        // Constructors -
        // TO DO: Rename row and column
        public CaveRoom(int row, int column)
        {
            Location = new Location(row, column);
            CaveRoomType = CaveRoomType.Normal;

            if (Location.Equals(Cave.CaveEntrance))
            {
                CaveRoomType = CaveRoomType.Entrance;
            }

            if (Location.Equals(Cave.FountainLocation))
            {
                Fountain = new Fountain(Cave.FountainLocation);
            }

            foreach (Location pit in Cave.PitLocations)
            {
                if (Location.Equals(pit))
                {
                    CaveRoomType = CaveRoomType.Pit;
                    break;
                }
            }

            foreach (Location maelstrom in Cave.MaelstromLocations)
            {
                if (Location.Equals(maelstrom))
                {
                    CaveRoomType = CaveRoomType.Maelstrom;
                    break;
                }
            }
        }

        // Methods -
        public List<CaveRoomType> GetAdjacentCaveRoomTypes(Cave cave)
        {
            List<CaveRoomType> adjacentCaveRoomTypes = new List<CaveRoomType>() { };

            for (int deltaRow = -1; deltaRow <= 1; deltaRow++)
            {
                for (int deltaColumn = -1; deltaColumn <= 1; deltaColumn++)
                {
                    if (deltaRow == 0 && deltaColumn == 0)
                    {
                        continue;
                    }

                    int adjacentRow = Location.Row + deltaRow;
                    int adjacentColumn = Location.Column + deltaColumn;

                    if (adjacentRow >= 0 && adjacentRow < cave.AmountOfCaveRows && adjacentColumn >= 0 && adjacentColumn < cave.AmountOfCaveColumns)
                    {
                        adjacentCaveRoomTypes.Add(cave.CaveRoom[adjacentRow, adjacentColumn].CaveRoomType);
                    }
                }
            }

            return adjacentCaveRoomTypes;
        }
    }
}
