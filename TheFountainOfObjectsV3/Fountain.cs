namespace TheFountainOfObjectsV3
{
    public class Fountain
    {
        // Variables -

        // Properties -
        public Location Location { get; set; }
        public bool IsEnabled { get; set; }

        // Constructors -
        public Fountain(Location fountainLocation)
        {
            Location = fountainLocation;
            IsEnabled = false;
        }

        // Methods -

    }
}
