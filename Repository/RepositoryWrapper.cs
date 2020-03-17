using Repository.Contracts;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IActivityRepository _activity;
        private IMoodRepository _mood;
        private IMoodTrackerRepository _moodTracker;
        private IPlaylistRatingRepository _playlistRating;

        public IActivityRepository Activities
        {
            get
            {
                if (_activity == null)
                {
                    _activity = new ActivityRepository(_context);
                }
                return _activity;
            }
        }
        public IMoodRepository Moods
        {
            get
            {
                if (_mood == null)
                {
                    _mood = new MoodRepository(_context);
                }
                return _mood;
            }
        }
        public IMoodTrackerRepository MoodTrackers
        {
            get
            {
                if (_moodTracker == null)
                {
                    _moodTracker = new MoodTrackerRepository(_context);
                }
                return _moodTracker;
            }
        }
        public IPlaylistRatingRepository PlaylistRatings
        {
            get
            {
                if (_playlistRating == null)
                {
                    _playlistRating = new PlaylistRatingRepository(_context);
                }
                return _playlistRating;
            }
        }
        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
