using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballApp.Models
{
    public static class GamesModels
    {
        public class GameResponse 
        { 
            public List<Game> Response { get; set; } 
        }
        public class Game
        {
            public int Id { get; set; }
            public string Date { get; set; }
            public string Status { get; set; }
            public League League { get; set; }
            public Team Home { get; set; }
            public Team Away { get; set; }
        }

        public class LeagueResponse 
        { 
            public List<League> Response { get; set; } 
        }
        public class League
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }
        }

        public class StandingsResponse 
        { 
            public List<Standing> Response { get; set; } 
        }
        public class Standing
        {
            public int Rank { get; set; }
            public Team Team { get; set; }
            public int Points { get; set; }
        }

        public class Team
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
