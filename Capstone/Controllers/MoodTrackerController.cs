using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Capstone.Contracts;
using Capstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class MoodTrackerController : Controller
    {

        private readonly IDatabaseService _databaseService;
        private readonly UserManager<IdentityUser> _userManager;

        public MoodTrackerController(UserManager<IdentityUser> userManager, IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var moodTracker = new MoodTracker();
            return View(moodTracker);
        }

        [HttpPost]
        public async Task<ActionResult> Create(MoodTracker moodTracker)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    moodTracker.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    await _databaseService.AddMoodTrackerAsync(moodTracker);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(moodTracker);
            }
        }
    }
}