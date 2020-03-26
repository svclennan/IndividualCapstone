using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Data
{
    class MoodTrackerRepository: RepositoryBase<MoodTracker>, IMoodTrackerRepository
    {
        public MoodTrackerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        
        public void CreateMoodTracker(MoodTracker newMoodTracker)
        {
            Create(newMoodTracker);
        }

        public MoodTracker GetMoodTracker(int moodTrackerId)
        {
            return FindByCondition(a => a.MoodTrackerId == moodTrackerId).FirstOrDefault();
        }

        public MoodTracker GetMoodTrackerByUserId(string userId)
        {
            return FindByCondition(a => a.UserId == userId).FirstOrDefault();
        }

        //include all things
        public List<MoodTracker> GetMoodTrackers()
        {
            return FindAll().ToList();
        }
    }
}
