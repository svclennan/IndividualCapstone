using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Contracts
{
    public interface IDatabaseService
    {
        Task AddMoodTrackerAsync(MoodTracker moodTracker);
        Task AddMoodAsync(Mood mood);
        Task AddPlaylistRatingAsync(PlaylistRating playlistRating);
        Task AddActivityAsync(Activity activity);
        Task<MoodTracker> GetMoodTrackerAsync(int id);
        Task<MoodTracker> GetMoodTrackerAsync(string userId);
        Task<List<MoodTracker>> GetMoodTrackersAsync();
        Task<Mood> GetMoodAsync(int id);
        Task<List<Mood>> GetMoodsAsync();
        Task<PlaylistRating> GetPlaylistRatingAsync(int id);
        Task<List<PlaylistRating>> GetPlaylistRatingsAsync();
        Task<Activity> GetActivityAsync(int id);
        Task<List<Activity>> GetActivityAsync();

    }
}
