namespace TheFountainOfObjectsV3
{
    public class Cave
    {
        // Variables
        private int _amountOfCaveRows;
        private int _amountOfCaveColumns;
        private int _amountOfCaveRooms;
        private CaveRoom[,] _caveRoom; // This is an example of a mulitdimensional array.
        private CaveSize _size;
        private (int Row, int Column) _caveEntrance;
        private (int Row, int Column) _fountainLocation;

        // Properties
        public int AmountOfCaveRows
        {
            get { return _amountOfCaveRows; }
        }

        public int AmountOfCaveColumns
        {
            get { return _amountOfCaveColumns; }
        }

        public int AmountOfCaveRooms
        {
            get { return _amountOfCaveRooms; }
        }

        public CaveRoom[,] CaveRoom
        {
            get { return _caveRoom; }
        }

        public CaveSize Size
        {
            get { return _size; }
        }

        public (int Row, int Column) CaveEntrance
        {
            get { return _caveEntrance; }
        }

        public (int Row, int Column) FountainLocation
        {
            get { return _fountainLocation; }
        }

        // Constructors
        public Cave(CaveSize passedCaveSize)
        {
            if (passedCaveSize == CaveSize.Small)
            {
                _size = CaveSize.Small;
                _amountOfCaveRows = 4;
                _amountOfCaveColumns = 4;
                _amountOfCaveRooms = _amountOfCaveRows * _amountOfCaveColumns;
                _caveRoom = new CaveRoom[_amountOfCaveRows, _amountOfCaveColumns];
                _caveEntrance = (0, 0);
                _fountainLocation = (0, 1);

                int arrayCounter = 0;
                for (int columnCounter = 0; columnCounter < _amountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < _amountOfCaveRows; rowCounter++, arrayCounter++)
                    {
                        _caveRoom[rowCounter, columnCounter] = new CaveRoom(rowCounter, columnCounter, _caveEntrance, _fountainLocation);
                    }
                }
            }

            if (passedCaveSize == CaveSize.Medium)
            {
                _size = CaveSize.Medium;
                _amountOfCaveRows = 6;
                _amountOfCaveColumns = 6;
                _amountOfCaveRooms = _amountOfCaveRows * _amountOfCaveColumns;
                _caveRoom = new CaveRoom[_amountOfCaveRows, _amountOfCaveColumns];
                _caveEntrance = (0, 0);
                _fountainLocation = (0, 2);

                int arrayCounter = 0;
                for (int columnCounter = 0; columnCounter < _amountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < _amountOfCaveRows; rowCounter++, arrayCounter++)
                    {
                        _caveRoom[rowCounter, columnCounter] = new CaveRoom(rowCounter, columnCounter, _caveEntrance, _fountainLocation);
                    }
                }
            }

            if (passedCaveSize == CaveSize.Large)
            {
                _size = CaveSize.Large;
                _amountOfCaveRows = 8;
                _amountOfCaveColumns = 8;
                _amountOfCaveRooms = _amountOfCaveRows * _amountOfCaveColumns;
                _caveRoom = new CaveRoom[_amountOfCaveRows, _amountOfCaveColumns];
                _caveEntrance = (0, 0);
                _fountainLocation = (0, 3);

                int arrayCounter = 0;
                for (int columnCounter = 0; columnCounter < _amountOfCaveColumns; columnCounter++)
                {
                    for (int rowCounter = 0; rowCounter < _amountOfCaveRows; rowCounter++, arrayCounter++)
                    {
                        _caveRoom[rowCounter, columnCounter] = new CaveRoom(rowCounter, columnCounter, _caveEntrance, _fountainLocation);
                    }
                }
            }
        }

        // Methods
    }
}
