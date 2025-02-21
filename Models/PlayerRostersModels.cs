using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballApp.Models
{
    public static class PlayerRostersModels
    {
        public class Player
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Position Position { get; set; }
            public string Height { get; set; }
            public int JerseyNumber { get; set; }

            public string DisplayText => $"{JerseyNumber} - {FirstName} {LastName} ({Position})";
        }

        public class CourtPosition
        {
            public int PositionIndex { get; set; }
            public string JerseyNumber { get; set; } = "";
        }

        public enum Position
        {
            Setter,
            Outside,
            Middle,
            Opposite,
            Libero
        }
    }
}
