using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static VolleyballApp.Models.GamesModels;

namespace VolleyballApp.Services
{
    public static class VolleyballAPI
    {
        private static readonly string BaseUrl = "https://v1.volleyball.api-sports.io";

        // fetching api key from enviromental varialbes
        // good practise, rather than hard coded string inside the code it self
        private static readonly string ApiKey = Environment.GetEnvironmentVariable("API_KEY");

        private static async Task<string> HttpGet(string endpoint, Dictionary<string, string> queryParams = null)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "api-volleyball.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-apisports-key", ApiKey);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 0.0));
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            int timeout = 10000;
            client.Timeout = TimeSpan.FromMilliseconds(timeout);

            var url = $"{BaseUrl}/{endpoint}";
            if (queryParams != null)
            {
                var queryString = string.Join("&", queryParams.Select(q => $"{q.Key}={q.Value}"));
                url += "?" + queryString;
            }

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<List<Game>> GetGamesAsync(string date)
        {
            var json = await HttpGet("games", new Dictionary<string, string> { { "date", date } });
            return JsonSerializer.Deserialize<GameResponse>(json)?.Response ?? [];
        }

        public static async Task<List<League>> GetLeaguesLogosAsync(List<int> leagueIds)
        {
            var leagues = new List<League>();

            foreach (var id in leagueIds)
            {
                var json = await HttpGet("leagues", new Dictionary<string, string> { { "id", id.ToString() } });
                var response = JsonSerializer.Deserialize<LeagueResponse>(json);

                if (response?.Response != null)
                    leagues.AddRange(response.Response);
            }

            return leagues;
        }
    }
}
