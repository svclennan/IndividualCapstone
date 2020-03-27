using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Capstone.Contracts;
using Capstone.Models;
using Google.Apis.Calendar.v3.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class MoodTrackerController : Controller
    {

        private readonly IDatabaseService _databaseService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IGoogleCalendarService _calendarService;
        private readonly ISmsService _smsService;
        private readonly Random rand;
        private readonly IMusicService _musicService;

        public MoodTrackerController(UserManager<IdentityUser> userManager, IDatabaseService databaseService, IGoogleCalendarService calendarService, ISmsService smsService, IMusicService musicService)
        {
            _databaseService = databaseService;
            _userManager = userManager;
            _calendarService = calendarService;
            _smsService = smsService;
            rand = new Random();
            _musicService = musicService;
        }

        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var moodTracker = await _databaseService.GetMoodTrackerAsync(userId);
            var events = _calendarService.GetMoods();
            var sum = 0.0;
            var count = 0;
            if(events != null)
            {
                foreach (var eventItem in events.Items)
                {
                    if (eventItem.Description != "Activity")
                    {
                        sum += Convert.ToDouble(eventItem.Summary);
                        count++;
                    }
                }
            }
            var average = sum / count;
            ViewBag.Average = average;

            if (moodTracker == null)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View(moodTracker);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(MoodTracker moodTracker)
        {
            try
            {
                moodTracker.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _databaseService.AddMoodTrackerAsync(moodTracker);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(moodTracker);
            }
        }

        public ActionResult EnterMood()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EnterMood(Mood mood)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var moodTracker = await _databaseService.GetMoodTrackerAsync(userId);
            mood.MoodTrackerId = moodTracker.MoodTrackerId;
            mood.Date = DateTime.Now;
            _calendarService.AddMood(mood);
            await _databaseService.AddMoodAsync(mood);
            if(mood.MoodRating < 4)
            {
                return RedirectToAction(nameof(RecommendExercise));
            }
            else
            {
                return RedirectToAction(nameof(RecommendMusic));
            }
        }

        public ActionResult EnterEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnterEvent(Activity activity)
        {
            _calendarService.AddActivity(activity);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> RecommendExercise()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var moodTracker = await _databaseService.GetMoodTrackerAsync(userId);
            var id = rand.Next(1, 9);
            var activity = await _databaseService.GetActivityAsync(id);
            await _smsService.SendSMS(moodTracker.PhoneNumber, activity.Name);
            return RedirectToAction(nameof(RecommendMusic));
        }

        public async Task<ActionResult> SendNotification()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var moodTracker = await _databaseService.GetMoodTrackerAsync(userId);
            Events events = _calendarService.GetEvents();
            if (events != null)
            {
                string reminder = "Today's Events:\n";
                foreach (var eventItem in events.Items)
                {
                    if (eventItem.Description == "Activity")
                    {
                        reminder += string.Format($"You have {eventItem.Summary} at {eventItem.Start.DateTime} \n");
                    }
                }
                await _smsService.SendSMS(moodTracker.PhoneNumber, reminder);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> DailyReminder()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var moodTracker = await _databaseService.GetMoodTrackerAsync(userId);
            await _smsService.SendSMS(moodTracker.PhoneNumber, "Remember to enter your mood today!");
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> RecommendMusic()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var moodTracker = await _databaseService.GetMoodTrackerAsync(userId);
            ViewBag.playlistUrl = _musicService.GetPlaylistRecommendation(moodTracker.Genre);
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> RecommendMusic(string url, int rating)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var moodTracker = await _databaseService.GetMoodTrackerAsync(userId);
            var playlistRating = new PlaylistRating
            {
                PlaylistUrl = url
            };
            if (rating >= 5)
            {
                playlistRating.Rating = true;
            }
            else
            {
                playlistRating.Rating = false;
            }
            playlistRating.MoodTrackerId = moodTracker.MoodTrackerId;
            await _databaseService.AddPlaylistRatingAsync(playlistRating);
            return RedirectToAction(nameof(Index));
        }
    }
}