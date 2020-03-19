using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IMoodTrackerRepository : IRepositoryBase<MoodTracker>
    {
        MoodTracker GetMoodTracker(int moodTrackerId);

        MoodTracker GetMoodTrackerByUserId(string userId);

        void CreateMoodTracker(MoodTracker newMoodTracker);

        List<MoodTracker> GetMoodTrackers();
    }
}
