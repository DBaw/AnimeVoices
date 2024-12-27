using AnimeVoices.DTO;
using AnimeVoices.Models;
using AnimeVoices.Utilities;
using AnimeVoices.Utilities.Events;
using AnimeVoices.ViewModels.Content;
using AnimeVoices.Views.Content;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;

namespace AnimeVoices.ViewModels
{

    public partial class MainWindowViewModel : ObservableRecipient, IRecipient<SwitchContentView>
    {
        public ObservableObject MainMenuViewModel { get; set; }
        public ObservableObject UserPanelViewModel { get; set; }
        public ObservableObject TopBarViewModel { get; set; }


        [ObservableProperty]
        private ObservableObject _currentContentViewModel;

        [ObservableProperty]
        private ObservableObject _previousContentViewModel;

        private User _user;

        public MainWindowViewModel()
        {
            MainMenuViewModel = new MainMenuViewModel(Messenger);

            CurrentContentViewModel = new OverviewViewModel();
            TopBarViewModel = new TopBarViewModel(Messenger);
            UserPanelViewModel = new UserPanelViewModel();

            PreviousContentViewModel = CurrentContentViewModel;
            IsActive = true;

            List<int> favAnime = new List<int>() { 2, 3 };
            List<int> watchlist = new List<int>() { 4 };
            //_user = null;
            _user = new(1, favAnime, watchlist);
        }

        protected override void OnActivated()
        {
            Messenger.RegisterAll(this);
        }

        public void Receive(SwitchContentView message)
        {
            ContentTypes contentType = message.ContentType;
            PreviousContentViewModel = CurrentContentViewModel;

            switch(contentType)
            {
                case (ContentTypes.OVERVIEW):
                    CurrentContentViewModel = new OverviewViewModel();
                    break;
                case (ContentTypes.ANIMELIST):
                    CurrentContentViewModel = new AnimeInfoViewModel(_user);
                    break;
                case (ContentTypes.FAVOURITES):
                    CurrentContentViewModel = new FavouritesViewModel();
                    break;
                case (ContentTypes.WATCHLIST):
                    CurrentContentViewModel = new WatchlistViewModel();
                    break;
                case (ContentTypes.SETTINGS):
                    CurrentContentViewModel = new SettingsViewModel();
                    break;
            }
        }
    }
}
