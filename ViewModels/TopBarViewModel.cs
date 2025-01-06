using AnimeVoices.Utilities;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Threading.Tasks;

namespace AnimeVoices.ViewModels
{
    public partial class TopBarViewModel : BaseViewModel
    {

        public TopBarViewModel(IMessenger messenger) : base(messenger)
        {

        }

        [RelayCommand]
        private async Task ExitApp()
        {
            Environment.Exit(0);
        }

        [RelayCommand]
        private async Task HideApp()
        {

        }

        [RelayCommand]
        private async Task GoToSettings()
        {
            _messenger.Send(new SwitchContentView(ContentTypes.SETTINGS));
        }
    }
}
