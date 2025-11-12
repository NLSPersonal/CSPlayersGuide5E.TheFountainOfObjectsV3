namespace TheFountainOfObjectsV3
{
    public class CaveRoom
    {
        // Variables
        private (int Row, int Column) _caveRoomLocation; // TO DO change this to be _caveRoomLocation and its associated property.
        private CaveRoomType _caveRoomType;
        private Fountain? _fountain;

        // Properties
        public (int Row, int Column) CaveRoomLocation
        {
            get { return _caveRoomLocation; }
            set { _caveRoomLocation = value; }
        }

        public CaveRoomType CaveRoomType
        {
            get { return _caveRoomType; }
            set { _caveRoomType = value; }
        }

        public Fountain? Fountain
        {
            get { return _fountain; }
            set { _fountain = value; }
        }

        // Constructors
        public CaveRoom(int passedRow, int passedColumn, (int Row, int Column) passedCaveEntrance, (int Row, int Column) passedFountainLocation)
        {
            _caveRoomLocation = (Row: passedRow, Column: passedColumn);
            _caveRoomType = CaveRoomType.Normal;
            _fountain = null;

                if (_caveRoomLocation == passedCaveEntrance)
                {
                    _caveRoomType = CaveRoomType.Entrance;
                }

                if (_caveRoomLocation == passedFountainLocation)
                {
                    _caveRoomType = CaveRoomType.DisabledFountain;
                    _fountain = new Fountain();
                }
        }
    }
}
