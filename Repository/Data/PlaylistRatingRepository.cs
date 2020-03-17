using Repository.Contracts;
using Repository.Models;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public PlaylistRating GetPlaylistRating(int playlistRatingId)
        {
            throw new NotImplementedException();
        }

        public List<PlaylistRating> GetPlaylistRatings()
        {
            throw new NotImplementedException();
        }
    }
}
