using Microsoft.AspNetCore.Mvc;
using Repository.Contracts;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;

        public ActivityController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _repo.Activities.GetActivities();
        }

        [HttpGet("{id:int}")]
        public Activity Get(int id)
        {
            return _repo.Activities.GetActivity(id);
        }

        [HttpPost]
        public void Post(Activity activity)
        {
            var newActivity = new Activity
            {
                Name = activity.Name
            };
            _repo.Activities.CreateActivity(newActivity);
            _repo.Save();
        }

        [HttpPut]
        public void Put(Activity activity)
        {
            var activityToEdit = _repo.Activities.GetActivity(activity.ActivityId);
            activityToEdit.Name = activity.Name;
            _repo.Activities.Update(activityToEdit);
            _repo.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var activity = _repo.Activities.GetActivity(id);
            _repo.Activities.Delete(activity);
            _repo.Save();
        }
    }
}
