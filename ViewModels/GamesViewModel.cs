using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using VolleyballApp.Services;
using static VolleyballApp.Models.GamesModels;

namespace VolleyballApp.ViewModels
{
    public partial class GamesViewModel : ObservableObject
    {
        private readonly DataService _dataService;

        [ObservableProperty]
        public List<League> leagues = new();

        [ObservableProperty]
        public List<Game> games = new();
        public GamesViewModel(DataService dataService)
        {
            _dataService = dataService;
            _ = LoadLeaguesAsync();
        }

        private async Task LoadLeaguesAsync()
        {
            Leagues = await _dataService.GetLeaguesAsync();
            // Leagues is property of leagues, created through ObservableProperty
        }

        [RelayCommand]
        public async void SelectLeague(League selectedLeague)
        {
            if(selectedLeague != null) 
            {
                Games = await _dataService.GetGamesByDateAsync(DateTime.Now.ToString("yyyy-MM-dd"), selectedLeague.Id);   
            }
        }

    }
}
