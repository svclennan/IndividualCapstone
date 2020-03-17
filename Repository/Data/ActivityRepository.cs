using Repository.Contracts;
using Repository.Models;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public List<Activity> GetActivities()
        {
            throw new NotImplementedException();
        }

        public Activity GetActivity(int activityId)
        {
            throw new NotImplementedException();
        }
    }
}
