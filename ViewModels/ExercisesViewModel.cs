using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using VolleyballApp.Models;

namespace VolleyballApp.ViewModels
{
    public partial class ExercisesViewModel : ObservableObject
    {
        [ObservableProperty]
        public string message = "This is Exercises Screen";

        [ObservableProperty]
        private List<Exercise> exercises;

        [ObservableProperty]
        private Exercise selectedExercise;

        [ObservableProperty]
        private string selectedDifficulty;

        public List<string> DifficultyList => new List<string> { "Beginner", "Intermediate", "Expert" };

        public IEnumerable<Exercise> FilteredExercises => string.IsNullOrEmpty(SelectedDifficulty)
            ? Exercises
            : Exercises.Where(e => e.Difficulty == SelectedDifficulty);

        public ExercisesViewModel()
        {
            // Initialize list of 12 exercises
            Exercises = new List<Exercise>
            {
                new Exercise { Title = "Exercise 1", Difficulty = "Beginner", Description = "Description of exercise 1", Time = "5 mins" },
                new Exercise { Title = "Exercise 2", Difficulty = "Intermediate", Description = "Description of exercise 2", Time = "10 mins" },
                new Exercise { Title = "Exercise 3", Difficulty = "Expert", Description = "Description of exercise 3", Time = "15 mins" },
                new Exercise { Title = "Exercise 4", Difficulty = "Beginner", Description = "Description of exercise 4", Time = "5 mins" },
                new Exercise { Title = "Exercise 5", Difficulty = "Intermediate", Description = "Description of exercise 5", Time = "10 mins" },
                new Exercise { Title = "Exercise 6", Difficulty = "Expert", Description = "Description of exercise 6", Time = "15 mins" },
                new Exercise { Title = "Exercise 7", Difficulty = "Beginner", Description = "Description of exercise 7", Time = "5 mins" },
                new Exercise { Title = "Exercise 8", Difficulty = "Intermediate", Description = "Description of exercise 8", Time = "10 mins" },
                new Exercise { Title = "Exercise 9", Difficulty = "Expert", Description = "Description of exercise 9", Time = "15 mins" },
                new Exercise { Title = "Exercise 10", Difficulty = "Beginner", Description = "Description of exercise 10", Time = "5 mins" },
                new Exercise { Title = "Exercise 11", Difficulty = "Intermediate", Description = "Description of exercise 11", Time = "10 mins" },
                new Exercise { Title = "Exercise 12", Difficulty = "Expert", Description = "Description of exercise 12", Time = "15 mins" }
            };
        }
    }

    public class Exercise
    {
        public string Title { get; set; }
        public string Difficulty { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
    }
}
