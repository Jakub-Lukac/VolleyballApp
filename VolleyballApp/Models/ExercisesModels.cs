using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballApp.Models
{
    public static class ExercisesModels
    {
        public enum Difficulty
        {
            Beginner,
            Intermediate,
            Expert,
            All,
        }
        public class Exercise
        {
            public int ExerciseId { get; set; }
            public string Title { get; set; }
            public string Difficulty { get; set; }
            public string Description { get; set; }
            public string Time { get; set; }
        }

        public class ExeriseData : DbContext
        {
            public ExeriseData() : base("MyExercisesData") { }

            public DbSet<Exercise> Exercises { get; set; } // creates exercises table
        }
    }
}
