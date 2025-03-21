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
        private ObservableCollection<League> leagues = new();

        [ObservableProperty]
        private ObservableCollection<Game> games = new();

        [ObservableProperty]
        private List<string> filters = new() { "All", "Live", "Canceled", "Finished" };

        [ObservableProperty]
        private string selectedFilter = "All"; // Default to "All"

        [ObservableProperty]
        private League selectedLeague;

        [ObservableProperty]
        private DateTime selectedDate = DateTime.Now;

        public GamesViewModel(DataService dataService)
        {
            _dataService = dataService;
            _ = LoadLeaguesAsync();
        }

        private async Task LoadLeaguesAsync()
        {
            Leagues =  new ObservableCollection<League>(await _dataService.GetLeaguesAsync());
            // Leagues is property of leagues, created through ObservableProperty
        }

        [RelayCommand]
        public async void SelectLeague(League selectedLeague)
        {
            if (selectedLeague != null)
            {
                SelectedLeague = selectedLeague; // Ensure selected league is updated
                await LoadGames();
            }
        }

        [RelayCommand]
        private async void SelectFilter(string filter)
        {
            SelectedFilter = filter;
            await LoadGames();
        }

        [RelayCommand]
        private async void SelectDate(DateTime date)
        {
            SelectedDate = date;
            await LoadGames();
        }

        private async Task LoadGames()
        {
            if (SelectedLeague == null)
            {
                Games = new ObservableCollection<Game>(); // Clear games if no league is selected
                return;
            }

            var allGames = await _dataService.GetGamesByDateAsync(SelectedDate.ToString("yyyy-MM-dd"), SelectedLeague.Id);

            // Apply filter
            Games = SelectedFilter switch
            {
                "Live" => new ObservableCollection<Game>(allGames.Where(g => g.Status.Short == "S1" || g.Status.Short == "S2" || g.Status.Short == "S3" || g.Status.Short == "S4" || g.Status.Short == "S5").ToList()),
                "Canceled" => new ObservableCollection<Game>(allGames.Where(g => g.Status.Short == "CANC").ToList()),
                "Finished" => new ObservableCollection<Game>(allGames.Where(g => g.Status.Short == "FT").ToList()),
                _ => new ObservableCollection<Game>(allGames) // Default case: show all games
            };
        }


    }
}
