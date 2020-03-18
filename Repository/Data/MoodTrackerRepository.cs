using Repository.Contracts;
using Repository.Models;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public MoodTracker GetMoodTracker(int moodTrackerId)
        {
            throw new NotImplementedException();
        }

        public MoodTracker GetMoodTrackerByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public MoodTracker GetMoodTrackerIncludeAll(int moodTrackerId)
        {
            throw new NotImplementedException();
        }
        //include all things
        public List<MoodTracker> GetMoodTrackers()
        {
            throw new NotImplementedException();
        }
    }
}
