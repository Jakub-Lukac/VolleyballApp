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
    /// Interaction logic for ExercisesView.xaml
    /// </summary>
    public partial class ExercisesView : UserControl
    {
        public ExercisesView(ExercisesViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void cbExercises_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is ExercisesViewModel viewModel && e.AddedItems.Count > 0)
            {
                viewModel.FilterExercisesCommand.Execute(e.AddedItems[0]);
            }
        }
    }
}
