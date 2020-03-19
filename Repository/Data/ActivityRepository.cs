using Repository.Contracts;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Data
{
    class ActivityRepository : RepositoryBase<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public void CreateActivity(Activity newActivity)
        {
            Create(newActivity);
        }

        public List<Activity> GetActivities()
        {
            return FindAll().ToList();
        }

        public Activity GetActivity(int activityId)
        {
            return FindByCondition(a => a.ActivityId == activityId).FirstOrDefault();
        }
    }
}
