using AnimeVoices.Utilities;
using AnimeVoices.Utilities.Events;
using AnimeVoices.ViewModels.Content;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels
{

    public partial class MainWindowViewModel : ObservableRecipient, IRecipient<SwitchContent>
    {
        public ObservableObject MainMenuViewModel { get; set; }
        public ObservableObject UserPanelViewModel { get; set; }
        public ObservableObject TopBarViewModel { get; set; }

        [ObservableProperty]
        private ObservableObject _currentContentViewModel;

        public MainWindowViewModel()
        {
            MainMenuViewModel = new MainMenuViewModel(Messenger);
            UserPanelViewModel = new UserPanelViewModel();
            TopBarViewModel = new TopBarViewModel(Messenger);
            CurrentContentViewModel = new OverviewViewModel();

            IsActive = true;
        }

        protected override void OnActivated()
        {
            Messenger.RegisterAll(this);
        }

        public void Receive(SwitchContent message)
        {
            ContentTypes contentType = message.ContentType;

            switch(contentType)
            {
                case (ContentTypes.SETTINGS):
                    CurrentContentViewModel = new SettingsViewModel();
                    break;
            }
        }
    }
}
