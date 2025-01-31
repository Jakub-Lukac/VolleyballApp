using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static VolleyballApp.Models.GamesModels;
using static VolleyballApp.Services.VolleyballAPI;

namespace VolleyballApp.ViewModels
{
    public partial class GamesViewModel : ObservableObject
    {
        [ObservableProperty]
        public string message = "This is Game Screen";

        public GamesViewModel()
        {
           // LoadLeagues();
           // LoadTodaysGames();
            LoadYesterdaysGames();
            //LoadTomorrowsGames();
        }

        private async void LoadLeagues()
        {
            var leagues = await GetLeaguesLogosAsync(new List<int> { 98, 99, 100 });
        }

        private async void LoadTodaysGames()
        {
            var games = await GetGamesAsync(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private async void LoadYesterdaysGames()
        {
            var games = await GetGamesAsync(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
        }

        private async void LoadTomorrowsGames()
        {
            var games = await GetGamesAsync(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
        }
    }
}
