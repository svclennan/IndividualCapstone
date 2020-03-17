using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IMoodTrackerRepository : IRepositoryBase<MoodTracker>
    {
        MoodTracker GetMoodTracker(int moodTrackerId);

        void CreateMoodTracker(MoodTracker newMoodTracker);

        MoodTracker GetMoodTrackerIncludeAll(int moodTrackerId);

        List<MoodTracker> GetMoodTrackers();
    }
}
