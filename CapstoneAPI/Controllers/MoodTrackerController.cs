using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Contracts;
using Repository.Models;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoodTrackerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;

        public MoodTrackerController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<MoodTracker> Get()
        {
            return _repo.MoodTrackers.GetMoodTrackers();
        }

        [HttpGet("{userId}")]
        public MoodTracker Get(string userId)
        {
            return _repo.MoodTrackers.GetMoodTrackerByUserId(userId);
        }

        [HttpGet("{id:int}")]
        public MoodTracker Get(int id)
        {
            return _repo.MoodTrackers.GetMoodTracker(id);
        }

        [HttpPost]
        public void Post(MoodTracker moodTracker)
        {
            var newMoodTracker = new MoodTracker
            {
                FirstName = moodTracker.FirstName,
                LastName = moodTracker.LastName,
                Genre = moodTracker.Genre,
                PhoneNumber = moodTracker.PhoneNumber,
                UserId = moodTracker.UserId
            };
            _repo.MoodTrackers.CreateMoodTracker(newMoodTracker);
            _repo.Save();
        }

        [HttpPut]
        public void Put(MoodTracker moodTracker)
        {
            var moodTrackerToEdit = _repo.MoodTrackers.GetMoodTrackerByUserId(moodTracker.UserId);
            moodTrackerToEdit.FirstName = moodTracker.FirstName;
            moodTrackerToEdit.LastName = moodTracker.LastName;
            moodTrackerToEdit.Genre = moodTracker.Genre;
            moodTrackerToEdit.PhoneNumber = moodTracker.PhoneNumber;
            _repo.MoodTrackers.Update(moodTrackerToEdit);
            _repo.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var moodTracker = _repo.MoodTrackers.GetMoodTracker(id);
            _repo.MoodTrackers.Delete(moodTracker);
            _repo.Save();
        }
    }
}
