using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IRepositoryWrapper
    {
        IActivityRepository Activities { get; }
        IMoodRepository Moods { get; }
        IMoodTrackerRepository MoodTrackers { get; }
        IPlaylistRatingRepository PlaylistRatings { get; }
        void Save();
    }
}
