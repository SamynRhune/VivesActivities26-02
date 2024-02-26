using Microsoft.EntityFrameworkCore;
using VivesActivities.Core;
using VivesActivities.Model;

namespace VivesActivities.Services
{
    public class VivesActivityService(VivesActivitiesDbContext dbContext)
    {
        public IList<VivesActivity> Find()
        {
            return dbContext.Activities
                .Include(a => a.Location)
                .ToList();
        }

        public VivesActivity? Get(int id)
        {
            return dbContext.Activities
                .Include(a => a.Location)
                .FirstOrDefault(a => a.Id == id);
        }

        public VivesActivity? Create(VivesActivity activity)
        {
            dbContext.Activities.Add(activity);
            dbContext.SaveChanges();

            return activity;
        }

        public VivesActivity? Update(int id, VivesActivity activity)
        {
            var dbActivity = dbContext.Activities
                .FirstOrDefault(a => a.Id == id);

            if (dbActivity is null)
            {
                return null;
            }

            dbActivity.Name = activity.Name;
            dbActivity.Description = activity.Description;
            dbActivity.Type = activity.Type;
            dbActivity.LocationId = activity.LocationId;

            dbContext.SaveChanges();

            return dbActivity;
        }

        public void Delete(int id)
        {
            var activity = dbContext.Activities
                .FirstOrDefault(a => a.Id == id);

            if (activity is null)
            {
                return;
            }

            dbContext.Activities.Remove(activity);

            dbContext.SaveChanges();
        }
    }
}
