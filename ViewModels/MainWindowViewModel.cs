using AnimeVoices.Utilities;
using AnimeVoices.Utilities.Events;
using AnimeVoices.ViewModels.Content;
using AnimeVoices.Views.Content;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

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

        public MainWindowViewModel()
        {
            MainMenuViewModel = new MainMenuViewModel(Messenger);

            UserPanelViewModel = new UserPanelViewModel();
            TopBarViewModel = new TopBarViewModel(Messenger);
            CurrentContentViewModel = new OverviewViewModel();

            PreviousContentViewModel = CurrentContentViewModel;
            IsActive = true;
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
                    CurrentContentViewModel = new AnimeInfoViewModel();
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
