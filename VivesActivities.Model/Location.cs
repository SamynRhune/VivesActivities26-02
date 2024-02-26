namespace VivesActivities.Model
{
    public class Location
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Building { get; set; }
        public string? Room { get; set; }
        public long? Latitude { get; set; }
        public long? Longitude { get; set; }

        public IList<VivesActivity> Activities { get; set; } = new List<VivesActivity>();
    }
}
