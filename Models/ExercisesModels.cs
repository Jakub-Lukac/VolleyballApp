using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballApp.Models
{
    public static class ExercisesModels
    {
        public enum Difficulty
        {
            Begginer,
            Intermediate,
            Expert
        }
        public class Exercise
        {
            public string Title { get; set; }
            public Difficulty Difficulty { get; set; }
            public string Description { get; set; }
            public string Time { get; set; }
        }
    }
}
