using Repository.Contracts;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Data
{
    class PlaylistRatingRepository : RepositoryBase<PlaylistRating>, IPlaylistRatingRepository
    {
        public PlaylistRatingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public void CreatePlaylistRating(PlaylistRating newPlaylistRating)
        {
            Create(newPlaylistRating);
        }

        public PlaylistRating GetPlaylistRating(int playlistRatingId)
        {
            return FindByCondition(a => a.PlaylistRatingId == playlistRatingId).FirstOrDefault();
        }

        public List<PlaylistRating> GetPlaylistRatings()
        {
            return FindAll().ToList();
        }
    }
}
