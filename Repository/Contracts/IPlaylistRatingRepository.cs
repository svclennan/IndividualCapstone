using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IPlaylistRatingRepository : IRepositoryBase<PlaylistRating>
    {
        PlaylistRating GetPlaylistRating(int playlistRatingId);

        void CreatePlaylistRating(PlaylistRating newPlaylistRating);

        List<PlaylistRating> GetPlaylistRatings();
    }
}
