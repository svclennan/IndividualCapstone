using Capstone.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Capstone.Services
{
    public class MusicService : IMusicService
    {
        public JToken GetPlaylistRecommendation(string genre)
        {
            var authClient = new RestClient("https://accounts.spotify.com/api/token");
            authClient.Timeout = -1;
            var authRequest = new RestRequest(Method.POST);
            authRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
            authRequest.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={Api_Keys.Spotify_ClientId}&client_secret={Api_Keys.Spotify_ClientSecret}", ParameterType.RequestBody);
            IRestResponse authResponse = authClient.Execute(authRequest);
            var authJson = authResponse.Content;
            var token = JObject.Parse(authJson)["access_token"].ToString();
            //var url = $"https://api/spotify.com/v1/browse/categories/{genre}/playlists?country=US&limit=1";
            //- H "Accept: application/json" - H "Content-Type: application/json" - H "Authorization: Bearer" + Api_Keys.Spotify_OAuth;
            /*
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Api_Keys.Spotify_OAuth}");
            string url = $"https://api/spotify.com/v1/browse/categories/{genre}/playlists?country=US&limit=1";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringContent = response.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(stringContent);
                string playlistUrl = json["playlists"]["items"][0]["external_urls"]["spotify"].ToString();
                return playlistUrl;
            }
            else
            {
                return "Invalid API Call";
            }*/
            var client = new RestClient($"https://api.spotify.com/v1/browse/categories/{genre.ToLower()}/playlists?country=US&limit=10");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {token}");
            IRestResponse response = client.Execute(request);
            var jsonString = response.Content;
            var playlistUrl = JObject.Parse(jsonString)["playlists"]["items"];
            return playlistUrl;

        }
    }
}
