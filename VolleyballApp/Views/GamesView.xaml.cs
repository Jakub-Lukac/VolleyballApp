using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VolleyballApp.ViewModels;

namespace VolleyballApp.Views
{
    /// <summary>
    /// Interaction logic for GamesView.xaml
    /// </summary>
    public partial class GamesView : UserControl
    {
        public GamesView(GamesViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void lwLeagues_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is GamesViewModel viewModel && e.AddedItems.Count > 0)
            {
                viewModel.SelectLeagueCommand.Execute(e.AddedItems[0]);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void lwFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is GamesViewModel viewModel && e.AddedItems.Count > 0)
            {
                viewModel.SelectFilterCommand.Execute(e.AddedItems[0]);
            }
        }

        private void dpSelectedDate_CalendarOpened(object sender, RoutedEventArgs e)
        {
            var datePicker = sender as DatePicker;
            if (datePicker != null)
            {
                datePicker.DisplayDateStart = DateTime.Today.AddDays(-1); // Yesterday
                datePicker.DisplayDateEnd = DateTime.Today.AddDays(1);    // Tomorrow
            }
        }

        private void dpSelectedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is GamesViewModel viewModel && e.AddedItems.Count > 0)
            {
                viewModel.SelectDateCommand.Execute(e.AddedItems[0]);
            }
        }
    }
}
