﻿using System;
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

        public MoodTrackerController(UserManager<IdentityUser> userManager, IDatabaseService databaseService, IGoogleCalendarService calendarService, ISmsService smsService)
        {
            _databaseService = databaseService;
            _userManager = userManager;
            _calendarService = calendarService;
            _smsService = smsService;
        }

        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(await _databaseService.GetMoodTrackerAsync(userId) == null)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                var moodTracker = await _databaseService.GetMoodTrackerAsync(userId);
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

            return RedirectToAction(nameof(Index));
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
    }
}