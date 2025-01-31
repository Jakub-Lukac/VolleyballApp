﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VolleyballApp.Views;

namespace VolleyballApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly GamesView _gamesView;
        private readonly PlayerRostersView _playerRostersView;
        private readonly ExercisesView _exercisesView;

        [ObservableProperty]
        private object currentView;

        public MainViewModel(GamesView gamesView, PlayerRostersView playerRostersView, ExercisesView exercisesView)
        {
            _gamesView = gamesView;
            _playerRostersView = playerRostersView;
            _exercisesView = exercisesView;

            // Set default view
            CurrentView = _gamesView;
        }

        [RelayCommand]
        private void ShowGames()
        {
            CurrentView = _gamesView;
        }

        [RelayCommand]
        private void ShowPlayerRosters()
        {
            CurrentView = _playerRostersView;
        }

        [RelayCommand]
        private void ShowExercises()
        {
            CurrentView = _exercisesView;
        }
    }
}
