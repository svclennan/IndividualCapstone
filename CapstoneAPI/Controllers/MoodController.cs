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
    public class MoodController : Controller
    {
        private readonly IRepositoryWrapper _repo;

        public MoodController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Mood> Get()
        {
            return _repo.Moods.GetMoods();
        }

        [HttpGet]
        public Mood Get(int id)
        {
            return _repo.Moods.GetMood(id);
        }

        [HttpPost]
        public void Post(Mood mood)
        {
            var newMood = new Mood
            {
                Date = mood.Date,
                MoodRating = mood.MoodRating,
                Note = mood.Note,
                MoodTrackerId = mood.MoodTrackerId
            };
            _repo.Moods.CreateMood(newMood);
            _repo.Save();
        }

        [HttpPut]
        public void Put(Mood mood)
        {
            var moodToEdit = _repo.Moods.GetMood(mood.MoodId);
            moodToEdit.Date = mood.Date;
            moodToEdit.MoodRating = mood.MoodRating;
            moodToEdit.Note = mood.Note;
            moodToEdit.MoodTrackerId = mood.MoodTrackerId;
            _repo.Moods.Update(moodToEdit);
            _repo.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var mood = _repo.Moods.GetMood(id);
            _repo.Moods.Delete(mood);
            _repo.Save();
        }
    }
}
