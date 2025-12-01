namespace TheFountainOfObjectsV3
{
    public readonly record struct Location
    {
        // Variables

        // Properties
        public int Row { get; init; }
        public int Column { get; init; }

        // Constructors
        public Location(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Location(Location location)
        {
            Row = location.Row;
            Column = location.Column;
        }

        // Methods

    }
}
