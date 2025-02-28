using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VolleyballApp.Models;
using VolleyballApp.Services;
using static VolleyballApp.Models.ExercisesModels;

namespace VolleyballApp.ViewModels
{
    public partial class ExercisesViewModel : ObservableObject
    {
        private readonly DataService _dataService;

        [ObservableProperty]
        public string message = "This is Exercises Screen";

        [ObservableProperty]
        private List<Exercise> exercises;

        [ObservableProperty]
        private Exercise selectedExercise;

        [ObservableProperty]
        private List<Exercise> filteredExercises;

        [ObservableProperty]
        private string selectedDifficulty;

        [ObservableProperty]
        public Difficulty[] difficultyList;

        public ExercisesViewModel(DataService dataService)
        {
            _dataService = dataService;
            DifficultyList = Enum.GetValues<Difficulty>();
            _ = LoadExercises();
        }

        private async Task LoadExercises()
        {
            var loadedExercises = await _dataService.GetExercisesAsync();
            Exercises = new List<Exercise>(loadedExercises);
            FilteredExercises = Exercises;
        }

        [RelayCommand]
        private void FilterExercises(Difficulty difficulty)
        {
            FilteredExercises = Exercises.Where(e => e.Difficulty == difficulty).ToList();
        }
    }

   
}
