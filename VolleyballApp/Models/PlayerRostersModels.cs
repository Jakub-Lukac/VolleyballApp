using CommunityToolkit.Mvvm.ComponentModel;
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
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Position Position { get; set; }
            public int Height { get; set; }
            public int JerseyNumber { get; set; }

            public string DisplayText => $"{JerseyNumber} - {FirstName} {LastName} ({Position})";
        }

        public class CourtPosition : ObservableObject
        {
            public int PositionIndex { get; set; }

            private string playerNumber;
            public string PlayerNumber
            {
                get => playerNumber;
                set => SetProperty(ref playerNumber, value);
            }

            public int? PlayerId { get; set; }
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
