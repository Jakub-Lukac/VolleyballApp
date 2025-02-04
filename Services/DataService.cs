using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VolleyballApp.Models.GamesModels;
using static VolleyballApp.Services.VolleyballAPI;

namespace VolleyballApp.Services
{
    public class DataService
    {
        private static List<League> _leagues;
        private readonly List<int> _leagueIds = new() { 60, 66, 98, 118, 180, };

        private static List<Game> _games;

        public async Task<List<League>> GetLeaguesAsync()
        {
            if (_leagues == null)
            {
                _leagues = await GetLeaguesLogosAsync(_leagueIds);
            }
            return _leagues;
        }

        public async Task<List<Game>> GetGamesByDateAsync(string date, int selectedLeagueId)
        {
            if (_games == null)
            {
                _games = await GetGamesAsync(date);
                _games = _games.Where(game => game.League.Id == selectedLeagueId).ToList();
            }
            return _games;
        }
    }

}
