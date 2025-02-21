using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace VolleyballApp.ViewModels
{
    public partial class PlayerRostersViewModel : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<Player> players = new();
        [ObservableProperty] private ObservableCollection<CourtPosition> courtPositions = new();
        [ObservableProperty] private Player selectedPlayer;
        [ObservableProperty] private CourtPosition selectedCourtCell;

        [ObservableProperty] private string firstName;
        [ObservableProperty] private string lastName;
        [ObservableProperty] private Position selectedPosition;
        [ObservableProperty] private string height;
        [ObservableProperty] private string jerseyNumber;

        [ObservableProperty] private Position[] positions;

        public PlayerRostersViewModel()
        {
            // Initialize 6 court positions
            for (int i = 0; i < 6; i++)
                CourtPositions.Add(new CourtPosition { PositionIndex = i });
            positions = Enum.GetValues<Position>();
        }

        [RelayCommand]
        private void AddPlayerToRoster()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(JerseyNumber))
                return;

            if (!int.TryParse(JerseyNumber, out int jerseyNum))
                return;

            Players.Add(new Player
            {
                FirstName = FirstName,
                LastName = LastName,
                Position = SelectedPosition,
                Height = Height,
                JerseyNumber = jerseyNum
            });

            // Clear fields
            FirstName = LastName = Height = JerseyNumber = string.Empty;
        }

        [RelayCommand]
        private void AddPlayerToCourt()
        {
            if (SelectedPlayer != null && SelectedCourtCell != null)
            {
                SelectedCourtCell.PlayerNumber = SelectedPlayer.JerseyNumber.ToString();
                SelectedCourtCell.PlayerId = SelectedPlayer.Id;
                SelectedCourtCell = null; // Unselect
            }
        }

        [RelayCommand]
        private void RemovePlayerFromCourt()
        {
            if (SelectedCourtCell != null)
            {
                SelectedCourtCell.PlayerNumber = null;
                SelectedCourtCell.PlayerId = null;
                SelectedCourtCell = null;
            }
        }
    }

    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }
        public string Height { get; set; }
        public int JerseyNumber { get; set; }
        public string DisplayText => $"{FirstName} {LastName} - #{JerseyNumber}";
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
        OutsideHitter,
        MiddleBlocker,
        Libero,
        OppositeHitter
    }
}
