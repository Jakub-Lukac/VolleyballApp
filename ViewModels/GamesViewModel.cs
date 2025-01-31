using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballApp.ViewModels
{
    public partial class GamesViewModel : ObservableObject
    {
        [ObservableProperty]
        public string message = "This is Game Screen";
    }
}
