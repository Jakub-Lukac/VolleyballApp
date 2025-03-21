using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolleyballApp.Models;
using VolleyballApp.Services;
using VolleyballApp.ViewModels;
using static VolleyballApp.Models.ExercisesModels;

namespace VolleyballApp.Tests
{
    public class ExercisesViewModelTests
    {
        private Mock<DataService> _mockDataService;
        private ExercisesViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
            _mockDataService = new Mock<DataService>();
            _viewModel = new ExercisesViewModel(_mockDataService.Object);
        }

        [Test]
        public void FilterExercises_ShouldFilterByDifficulty()
        {
            // Arrange
            _viewModel.Exercises = new List<Exercise>
            {
                new Exercise { Title = "Exercise 1", Difficulty = "Easy" },
                new Exercise { Title = "Exercise 2", Difficulty = "Intermediate" },
                new Exercise { Title = "Exercise 3", Difficulty = "Hard" }
            };

            // Act
            _viewModel.FilterExercises(Difficulty.Intermediate);

            // Assert
            Assert.That(_viewModel.FilteredExercises.Count, Is.EqualTo(1));
            Assert.That(_viewModel.FilteredExercises.First().Difficulty, Is.EqualTo("Intermediate"));
        }

        [Test]
        public void FilterExercises_WithAll_ShouldReturnAllExercises()
        {
            // Arrange
            _viewModel.Exercises = new List<Exercise>
            {
                new Exercise { Title = "Exercise 1", Difficulty = "Easy" },
                new Exercise { Title = "Exercise 2", Difficulty = "Intermediate" },
                new Exercise { Title = "Exercise 3", Difficulty = "Hard" }
            };

            // Act
            _viewModel.FilterExercises(Difficulty.All);

            // Assert
            Assert.That(_viewModel.FilteredExercises.Count, Is.EqualTo(3));
        }
    }
}
