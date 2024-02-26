using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VivesActivities.Model;

namespace VivesActivities.Core
{
    public class VivesActivitiesDbContext: IdentityDbContext
    {
        public VivesActivitiesDbContext(DbContextOptions<VivesActivitiesDbContext> options): base(options)
        {
            
        }
        public DbSet<VivesActivity> Activities => Set<VivesActivity>();
        public DbSet<Location> Locations => Set<Location>();

        public void Seed()
        {
            var location = new Location { Name = "Technology building" };
            Locations.Add(location);
            Locations.Add(new Location { Name = "HWB Building" });
            Locations.Add(new Location { Name = "Vives Forum" });

            Activities.AddRange(new List<VivesActivity>
            {
                new VivesActivity
                {
                    Name = "Soccer",
                    Type = "Team Sport",
                    Location = location,
                    Description = "Description of Soccer"
                },
                new VivesActivity
                {
                    Name = "Tennis",
                    Type = "Individual Sport",
                    Location = location,
                    Description = "Description of Tennis"
                },
                new VivesActivity
                {
                    Name = "Basketball",
                    Type = "Team Sport",
                    Location = location,
                    Description = "Description of Basketball"
                },
                new VivesActivity
                {
                    Name = "Swimming",
                    Type = "Individual Sport",
                    Location = location,
                    Description = "Description of Swimming"
                },
                new VivesActivity
                {
                    Name = "Volleyball",
                    Type = "Team Sport",
                    Location = location,
                    Description = "Description of Volleyball"
                },
                new VivesActivity
                {
                    Name = "Golf",
                    Type = "Individual Sport",
                    Location = location,
                    Description = "Description of Golf"
                },
                new VivesActivity
                {
                    Name = "Badminton",
                    Type = "Individual Sport",
                    Location = location,
                    Description = "Description of Badminton"
                },
                new VivesActivity
                {
                    Name = "Hockey",
                    Type = "Team Sport",
                    Location = location,
                    Description = "Description of Hockey"
                },
                new VivesActivity
                {
                    Name = "Table Tennis",
                    Type = "Individual Sport",
                    Location = location,
                    Description = "Description of Table Tennis"
                },
                new VivesActivity
                {
                    Name = "Rugby",
                    Type = "Team Sport",
                    Location = location,
                    Description = "Description of Rugby"
                }
            });

            SaveChanges();
        }
    }
}
