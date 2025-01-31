using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VolleyballApp.Models
{
    public static class GamesModels
    {
        #region Games
        public class GameResponse 
        {
            [JsonPropertyName("response")]
            public List<Game> Response { get; set; } 
        }
        public class Game
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("date")]
            public string Date { get; set; }

            [JsonPropertyName("status")]
            public GameStatus Status { get; set; }

            [JsonPropertyName("league")]
            public GamesLeague League { get; set; }

            [JsonPropertyName("teams")]
            public Teams Teams { get; set; }

            [JsonPropertyName("scores")]
            public Scores Scores { get; set; }

            [JsonPropertyName("periods")]
            public Periods Periods { get; set; }
        }

        public class GameStatus
        {
            [JsonPropertyName("long")]
            public string Long { get; set; }

            [JsonPropertyName("short")]
            public string Short { get; set; }
        }

        public class GamesLeague
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }
        }

        public class Teams
        {
            [JsonPropertyName("home")]
            public Team Home { get; set; }

            [JsonPropertyName("away")]
            public Team Away { get; set; }
        }

        public class Team
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("logo")]
            public string Logo { get; set; }
        }

        public class Scores
        {
            [JsonPropertyName("home")]
            public int? Home { get; set; } // int?, handles nulls (allows them to be passed)

            [JsonPropertyName("away")]
            public int? Away { get; set; }
        }

        public class Periods
        {
            [JsonPropertyName("first")]
            public Period First { get; set; }

            [JsonPropertyName("second")]
            public Period Second { get; set; }

            [JsonPropertyName("third")]
            public Period Third { get; set; }

            [JsonPropertyName("fourth")]
            public Period Fourth { get; set; }

            [JsonPropertyName("fifth")]
            public Period Fifth { get; set; }
        }

        public class Period
        {
            [JsonPropertyName("home")]
            public int? Home { get; set; }

            [JsonPropertyName("away")]
            public int? Away { get; set; }
        }

        #endregion 

        #region League

        public class League
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]  // This maps to "name" inside the League object
            public string Name { get; set; }

            [JsonPropertyName("logo")]
            public string Logo { get; set; }

            [JsonPropertyName("country")] // country : {...} (JSON within JSON)
            public CountryInfo Country { get; set; }
        }

        public class CountryInfo
        {
            [JsonPropertyName("name")]  // This maps to "name" inside the "country" object
            public string Name { get; set; }
        }

        public class LeagueResponse
        {
            [JsonPropertyName("response")]
            public List<League> Response { get; set; }
        }

        #endregion
    }
}
