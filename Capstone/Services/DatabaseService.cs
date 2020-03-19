using Capstone.Contracts;
using Capstone.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IConfiguration _config;

        public DatabaseService(IConfiguration config)
        {
            _config = config;
        }
        public async Task AddActivityAsync(Activity activity)
        {
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += "api/Activity";
            var json = JsonConvert.SerializeObject(activity);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(url, data);
        }

        public async Task AddMoodAsync(Mood mood)
        {
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += "api/Mood";
            var json = JsonConvert.SerializeObject(mood);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(url, data);
        }

        public async Task AddMoodTrackerAsync(MoodTracker moodTracker)
        {
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += "api/MoodTracker";
            var json = JsonConvert.SerializeObject(moodTracker);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(url, data);
        }

        public async Task AddPlaylistRatingAsync(PlaylistRating playlistRating)
        {
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += "api/PlaylistRating";
            var json = JsonConvert.SerializeObject(playlistRating);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(url, data);
        }

        public async Task<Activity> GetActivityAsync(int id)
        {
            HttpClient client = new HttpClient();
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += $"api/Activity/{id}";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Activity>(json);
            }
            return null;
        }

        public async Task<List<Activity>> GetActivityAsync()
        {
            HttpClient client = new HttpClient();
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += $"api/Activity";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Activity>>(json);
            }
            return null;
        }

        public async Task<Mood> GetMoodAsync(int id)
        {
            HttpClient client = new HttpClient();
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += $"api/Mood/{id}";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Mood>(json);
            }
            return null;
        }

        public async Task<List<Mood>> GetMoodsAsync()
        {
            HttpClient client = new HttpClient();
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += $"api/Mood";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Mood>>(json);
            }
            return null;
        }

        public async Task<MoodTracker> GetMoodTrackerAsync(int id)
        {
            HttpClient client = new HttpClient();
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += $"api/MoodTracker/{id}";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<MoodTracker>(json);
            }
            return null;
        }

        public async Task<MoodTracker> GetMoodTrackerAsync(string userId)
        {
            HttpClient client = new HttpClient();
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += $"api/MoodTracker/{userId}";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<MoodTracker>(json);
            }
            return null;
        }

        public async Task<List<MoodTracker>> GetMoodTrackersAsync()
        {
            HttpClient client = new HttpClient();
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += $"api/MoodTracker";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<MoodTracker>>(json);
            }
            return null;
        }

        public async Task<PlaylistRating> GetPlaylistRatingAsync(int id)
        {
            HttpClient client = new HttpClient();
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += $"api/PlaylistRating/{id}";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<PlaylistRating>(json);
            }
            return null;
        }

        public async Task<List<PlaylistRating>> GetPlaylistRatingsAsync()
        {
            HttpClient client = new HttpClient();
            string url = _config.GetValue<string>("ApiHostUrl:BaseUrl");
            url += $"api/PlaylistRating";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<PlaylistRating>>(json);
            }
            return null;
        }
    }
}
