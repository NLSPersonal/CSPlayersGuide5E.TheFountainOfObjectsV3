namespace TheFountainOfObjectsV3
{
    public class CaveRoom
    {
        // Variables
        // Properties
        public (int Row, int Column) CaveRoomLocation { get; set; }

        public CaveRoomType CaveRoomType { get; set; }

        public Fountain? Fountain { get; set; }

        // Constructors
        public CaveRoom(int Row, int Column, (int Row, int Column) CaveEntrance, (int Row, int Column) FountainLocation)
        {
            CaveRoomLocation = (Row: Row, Column: Column);
            CaveRoomType = CaveRoomType.Normal;
            Fountain = null;

            if (CaveRoomLocation == CaveEntrance)
            {
                CaveRoomType = CaveRoomType.Entrance;
            }

            if (CaveRoomLocation == FountainLocation)
            {
                CaveRoomType = CaveRoomType.DisabledFountain;
                Fountain = new Fountain();
            }
        }
    }
}
