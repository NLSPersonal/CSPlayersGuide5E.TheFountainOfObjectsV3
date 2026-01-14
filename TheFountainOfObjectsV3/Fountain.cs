namespace TheFountainOfObjectsV3
{
    public class Fountain
    {
        // PROPERTIES
        public Location Location { get; set; }
        public bool IsEnabled { get; set; }

        // CONSTRUCTORS
        public Fountain(Location fountainLocation)
        {
            Location = fountainLocation;
            IsEnabled = false;
        }
    }
}
