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
        [ObservableProperty] private string _searchText;


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

        partial void OnSearchTextChanged(string oldValue, string newValue)
        {
            if (oldValue != newValue) 
            {
                _messenger.Send(new SearchTextChanged(newValue));
            }
        }
    }
}
