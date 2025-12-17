namespace TheFountainOfObjectsV3
{
    public class CaveRoom
    {
        // VARIABLES -

        // PROPERTIES -
        public Location Location { get; set; }

        public CaveRoomType CaveRoomType { get; set; }

        public Fountain? Fountain { get; set; }

        public Maelstrom? Maelstrom { get; set; }

        public Amarok? Amarok { get; set; }

        // CONSTRUCTORS -
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

            foreach (Location pitLocation in Cave.PitLocations)
            {
                if (Location.Equals(pitLocation))
                {
                    CaveRoomType = CaveRoomType.Pit;
                    break;
                }
            }

            foreach (Location maelstromLocation in Cave.MaelstromLocations)
            {
                if (Location.Equals(maelstromLocation))
                {
                    Maelstrom = new Maelstrom(maelstromLocation);
                    break;
                }
            }

            foreach (Location amarokLocation in Cave.AmarokLocations)
            {
                if (Location.Equals(amarokLocation))
                {
                    Amarok = new Amarok(amarokLocation);
                    break;
                }
            }
        }

        // METHODS -
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

        // TO DO: Combine CheckAdjacentCaveRoomsForMaelstroms and CheckAdjacentCaveRoomsForAmaroks into one method that takes a CreatureType parameter.
        // TO DO: Consider moving to Player class.
        public bool CheckAdjacentCaveRoomsForMaelstroms(Cave cave)
        {
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
                        CaveRoom adjacentCaveRoom = cave.CaveRoom[adjacentRow, adjacentColumn];
                        if (adjacentCaveRoom.Maelstrom != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CheckAdjacentCaveRoomsForAmaroks(Cave cave)
        {
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
                        CaveRoom adjacentCaveRoom = cave.CaveRoom[adjacentRow, adjacentColumn];
                        if (adjacentCaveRoom.Amarok != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
