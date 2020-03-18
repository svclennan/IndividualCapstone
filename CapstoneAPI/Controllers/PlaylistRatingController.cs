using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Contracts;
using Repository.Models;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistRatingController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;

        public PlaylistRatingController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<PlaylistRating> Get()
        {
            return _repo.PlaylistRatings.GetPlaylistRatings();
        }
        [HttpGet("{id:int}")]
        public PlaylistRating Get(int id)
        {
            return _repo.PlaylistRatings.GetPlaylistRating(id);
        }

        [HttpPost]
        public void Post(PlaylistRating playlistRating)
        {
            var newPlayListRating = new PlaylistRating
            {
                PlaylistUrl = playlistRating.PlaylistUrl,
                Rating = playlistRating.Rating,
                MoodTrackerId = playlistRating.MoodTrackerId
            };
            _repo.PlaylistRatings.CreatePlaylistRating(newPlayListRating);
            _repo.Save();
        }

        [HttpPut]
        public void Put(PlaylistRating playlistRating)
        {
            var ratingToEdit = _repo.PlaylistRatings.GetPlaylistRating(playlistRating.PlaylistRatingId);
            ratingToEdit.PlaylistUrl = playlistRating.PlaylistUrl;
            ratingToEdit.MoodTrackerId = playlistRating.MoodTrackerId;
            ratingToEdit.Rating = playlistRating.Rating;
            _repo.PlaylistRatings.Update(ratingToEdit);
            _repo.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rating = _repo.PlaylistRatings.GetPlaylistRating(id);
            _repo.PlaylistRatings.Delete(rating);
            _repo.Save();
        }
    }
}