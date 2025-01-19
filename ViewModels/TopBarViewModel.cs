using AnimeVoices.Utilities;
using AnimeVoices.Utilities.Events;
using AnimeVoices.Views;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Threading.Tasks;

namespace AnimeVoices.ViewModels
{
    public partial class TopBarViewModel : BaseViewModel
    {
        [ObservableProperty] private string? _searchText;

        private MainWindow _mainWindow;




        public TopBarViewModel(IMessenger messenger, MainWindow mainWindow) : base(messenger)
        {
            _mainWindow = mainWindow;
        }

        [RelayCommand]
        private void ExitApp()
        {
            Environment.Exit(0);
        }

        [RelayCommand]
        private async Task MinimizeApp()
        {
            _mainWindow.WindowState = WindowState.Minimized;
        }

        [RelayCommand]
        private void GoToAbout()
        {
            _messenger.Send(new SwitchContentView(ContentTypes.ABOUT));
        }

        partial void OnSearchTextChanged(string value)
        {
            _messenger.Send(new SearchTextChanged(value));
        }
    }
}
