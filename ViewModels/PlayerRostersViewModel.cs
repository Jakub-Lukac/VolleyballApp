using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using static VolleyballApp.Models.PlayerRostersModels;

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

            if (!int.TryParse(Height, out int height))
                return;

            if (!int.TryParse(JerseyNumber, out int jerseyNum))
                return;

            Players.Add(new Player
            {
                FirstName = FirstName,
                LastName = LastName,
                Position = SelectedPosition,
                Height = height,
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
                // Check if the player is already assigned to another court position
                if (CourtPositions.Any(cp => cp.PlayerId == SelectedPlayer.Id))
                {
                    // Player is already assigned to a court position, show a message or return
                    return;
                }

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
}
