using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace AnimeVoices.ViewModels
{
    public partial class TopBarViewModel : ObservableObject
    {
        public TopBarViewModel()
        {
            
        }

        [RelayCommand]
        private async Task ExitApp()
        {
            Environment.Exit(0);
        }
    }
}
