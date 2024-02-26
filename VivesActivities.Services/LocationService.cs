using Microsoft.EntityFrameworkCore;
using VivesActivities.Core;
using VivesActivities.Model;

namespace VivesActivities.Services
{
    public class LocationService(VivesActivitiesDbContext dbContext)
    {
        public IList<Location> Find()
        {
            return dbContext.Locations
                .ToList();
        }

        public Location? Get(int id)
        {
            return dbContext.Locations
                .FirstOrDefault(a => a.Id == id);
        }

        public Location? Create(Location location)
        {
            dbContext.Locations.Add(location);
            dbContext.SaveChanges();

            return location;
        }

        public Location? Update(int id, Location location)
        {
            var dbLocation = dbContext.Locations
                .FirstOrDefault(a => a.Id == id);

            if (dbLocation is null)
            {
                return null;
            }

            dbLocation.Name = location.Name;
            dbLocation.Description = location.Description;
            dbLocation.Building = location.Building;
            dbLocation.Room = location.Room;
            dbLocation.Latitude = location.Latitude;
            dbLocation.Longitude = location.Longitude;

            dbContext.SaveChanges();

            return dbLocation;
        }

        public void Delete(int id)
        {
            var location = dbContext.Locations
                .FirstOrDefault(a => a.Id == id);

            if (location is null)
            {
                return;
            }

            dbContext.Locations.Remove(location);

            dbContext.SaveChanges();
        }
    }
}
