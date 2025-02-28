using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VolleyballApp.Models.ExercisesModels;
using static VolleyballApp.Models.GamesModels;
using static VolleyballApp.Services.VolleyballAPI;

namespace VolleyballApp.Services
{
    public class DataService
    {
        #region Games
        private static List<League> _leagues;
        private readonly List<int> _leagueIds = new() { 24, 174 };

        private static List<Game> _games;

        public async Task<List<League>> GetLeaguesAsync()
        {

                _leagues = await GetLeaguesLogosAsync(_leagueIds);
            return _leagues;
        }

        public async Task<List<Game>> GetGamesByDateAsync(string date, int selectedLeagueId)
        {

                _games = await GetGamesAsync(date);
                _games = _games.Where(game => game.League.Id == selectedLeagueId).ToList();
            return _games;
        }
        #endregion

        #region Exercises

        private static List<Exercise> _exercises;

        public async Task<List<Exercise>> GetExercisesAsync()
        {
            // Simulating async data retrieval
            await Task.Delay(500);

            _exercises = new List<Exercise>
            {
                new Exercise { Title = "Exercise 1", Difficulty = Difficulty.Begginer, Description = "Description of exercise 1", Time = "5 mins" },
                new Exercise { Title = "Exercise 2", Difficulty = Difficulty.Intermediate, Description = "Description of exercise 2", Time = "10 mins" },
                new Exercise { Title = "Exercise 3", Difficulty = Difficulty.Expert, Description = "Description of exercise 3", Time = "15 mins" },
                new Exercise { Title = "Exercise 4", Difficulty = Difficulty.Begginer, Description = "Description of exercise 4", Time = "5 mins" },
                new Exercise { Title = "Exercise 5", Difficulty = Difficulty.Intermediate, Description = "Description of exercise 5", Time = "10 mins" },
                new Exercise { Title = "Exercise 6", Difficulty = Difficulty.Expert, Description = "Description of exercise 6", Time = "15 mins" },
                new Exercise { Title = "Exercise 7", Difficulty = Difficulty.Begginer, Description = "Description of exercise 7", Time = "5 mins" },
                new Exercise { Title = "Exercise 8", Difficulty = Difficulty.Intermediate, Description = "Description of exercise 8", Time = "10 mins" },
                new Exercise { Title = "Exercise 9", Difficulty = Difficulty.Expert, Description = "Description of exercise 9", Time = "15 mins" },
                new Exercise { Title = "Exercise 10", Difficulty = Difficulty.Begginer, Description = "Description of exercise 10", Time = "5 mins" },
                new Exercise { Title = "Exercise 11", Difficulty = Difficulty.Intermediate, Description = "Description of exercise 11", Time = "10 mins" },
                new Exercise { Title = "Exercise 12", Difficulty = Difficulty.Expert, Description = "Description of exercise 12", Time = "15 mins" }
            };

            return _exercises;
        }

        #endregion
    }

}
