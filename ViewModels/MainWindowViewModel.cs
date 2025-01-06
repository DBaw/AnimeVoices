using AnimeVoices.Utilities;
using AnimeVoices.Utilities.Events;
using AnimeVoices.ViewModels.Content;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels
{

    public partial class MainWindowViewModel : BaseViewModel, IRecipient<SwitchContentView>
    {
        public BaseViewModel MainMenuViewModel { get; set; }
        public BaseViewModel UserPanelViewModel { get; set; }
        public BaseViewModel TopBarViewModel { get; set; }

        [ObservableProperty]
        private BaseViewModel _currentContentViewModel;

        [ObservableProperty]
        private BaseViewModel _previousContentViewModel;

        // ViewModels
        private readonly MainMenuViewModel _mainMenuViewModel;
        private readonly OverviewViewModel _overviewViewModel;
        private readonly TopBarViewModel _topBarViewModel;
        private readonly UserPanelViewModel _userPanelViewModel;
        private readonly AnimeInfoViewModel _animeInfoViewModel;
        private readonly FavouritesViewModel _favouritesViewModel;
        private readonly WatchlistViewModel _watchlistViewModel;
        private readonly SettingsViewModel _settingsViewModel;

        public MainWindowViewModel(IMessenger messenger, MainMenuViewModel mainMenuViewModel,TopBarViewModel topBarViewModel, UserPanelViewModel userPanelViewModel, OverviewViewModel overviewViewModel, AnimeInfoViewModel animeInfoViewModel, FavouritesViewModel favouritesViewModel, WatchlistViewModel watchlistViewModel, SettingsViewModel settingsViewModel) : base(messenger)
        {
            _mainMenuViewModel = mainMenuViewModel;
            _topBarViewModel = topBarViewModel;
            _userPanelViewModel = userPanelViewModel;
            _overviewViewModel = overviewViewModel;
            _animeInfoViewModel = animeInfoViewModel;
            _favouritesViewModel = favouritesViewModel;
            _watchlistViewModel = watchlistViewModel;
            _settingsViewModel = settingsViewModel;

            MainMenuViewModel = _mainMenuViewModel;

            CurrentContentViewModel = _overviewViewModel;
            TopBarViewModel = _topBarViewModel;
            UserPanelViewModel = _userPanelViewModel;

            PreviousContentViewModel = CurrentContentViewModel;

            _messenger.RegisterAll(this);
        }

        public void Receive(SwitchContentView message)
        {
            ContentTypes contentType = message.ContentType;
            PreviousContentViewModel = CurrentContentViewModel;

            switch(contentType)
            {
                case (ContentTypes.OVERVIEW):
                    CurrentContentViewModel = _overviewViewModel;
                    break;
                case (ContentTypes.ANIMELIST):
                    CurrentContentViewModel = _animeInfoViewModel;
                    break;
                case (ContentTypes.FAVOURITES):
                    CurrentContentViewModel = _favouritesViewModel;
                    break;
                case (ContentTypes.WATCHLIST):
                    CurrentContentViewModel = _watchlistViewModel;
                    break;
                case (ContentTypes.SETTINGS):
                    CurrentContentViewModel = _settingsViewModel;
                    break;
            }
        }
    }
}
