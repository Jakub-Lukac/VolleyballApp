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
    /// Interaction logic for PlayerBoardsView.xaml
    /// </summary>
    public partial class PlayerRostersView : UserControl
    {
        public PlayerRostersView(PlayerRostersViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void GridCell_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
