using Capstone.Contracts;
using Capstone.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Capstone.Services
{
    public class GoogleCalendarService : IGoogleCalendarService
    {
        static string[] Scopes = { CalendarService.Scope.Calendar };
        static string ApplicationName = "Mood Tracker";

        public void AddActivity(Activity activity)
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var activityEvent = new Event();
            EventDateTime start = new EventDateTime();
            start.DateTime = activity.Date;

            EventDateTime end = new EventDateTime();
            end.DateTime = activity.Date.AddHours(1);

            activityEvent.Start = start;
            activityEvent.End = end;
            activityEvent.Summary = activity.Name;
            activityEvent.Description = "Activity";

            var calendarId = "oleh7r61e36f4qogdbvbunlfok@group.calendar.google.com";
            service.Events.Insert(activityEvent, calendarId).Execute();
        }

        public void AddMood(Mood mood)
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });


            var moodEvent = new Event();
            EventDateTime start = new EventDateTime();
            start.DateTime = mood.Date;
            EventDateTime end = new EventDateTime();
            end.DateTime = mood.Date.AddHours(1);

            moodEvent.Start = start;
            moodEvent.End = end;
            moodEvent.Summary = mood.MoodRating.ToString();
            moodEvent.Description = mood.Note;

            var calendarId = "oleh7r61e36f4qogdbvbunlfok@group.calendar.google.com";
            service.Events.Insert(moodEvent, calendarId).Execute();
        }

        public Events GetEvents()
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            EventsResource.ListRequest request = service.Events.List("oleh7r61e36f4qogdbvbunlfok@group.calendar.google.com");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.TimeMax = DateTime.Now.AddDays(1);
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = request.Execute();
            if (events.Items != null && events.Items.Count > 0)
            {
                return events;
            }
            else
            {
                return null;
            }
        }
    }
}
