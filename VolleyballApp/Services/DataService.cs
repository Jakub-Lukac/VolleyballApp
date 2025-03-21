using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static VolleyballApp.Models.ExercisesModels;
using static VolleyballApp.Models.GamesModels;
using static VolleyballApp.Services.VolleyballAPI;

namespace VolleyballApp.Services
{
    public class DataService
    {
        #region Games
        private static List<League> _leagues;
        private readonly List<int> _leagueIds = new() { 51, 104, 113, 139, 175,  };

        private static List<Game> _games;

        public async Task<List<League>> GetLeaguesAsync()
        {
            try
            {
                _leagues = await GetLeaguesLogosAsync(_leagueIds);
                return _leagues;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured when fetching league logos!");
                return [];
            }

        }

        public async Task<List<Game>> GetGamesByDateAsync(string date, int selectedLeagueId)
        {
            try
            {
                _games = await GetGamesAsync(date);
                _games = _games.Where(game => game.League.Id == selectedLeagueId).ToList();
                return _games;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured when fetching games!");
                return [];
            }

        }
        #endregion

        #region Exercises

        private static List<Exercise> _exercises;

        public async Task<List<Exercise>> GetExercisesAsync()
        {
            // initialize connection only when this method is called
            ExeriseData db = new ExeriseData();

            var query = from e in db.Exercises
                        select e;

            return query.ToList();
        }

        #endregion
    }

}
