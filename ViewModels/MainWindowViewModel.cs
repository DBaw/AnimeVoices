﻿using AnimeVoices.Utilities;
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
        private readonly SettingsViewModel _settingsViewModel;
        private readonly AboutAppViewModel _aboutAppViewModel;

        public MainWindowViewModel(IMessenger messenger, MainMenuViewModel mainMenuViewModel,TopBarViewModel topBarViewModel, UserPanelViewModel userPanelViewModel, OverviewViewModel overviewViewModel, AnimeInfoViewModel animeInfoViewModel, SettingsViewModel settingsViewModel, AboutAppViewModel aboutAppViewModel) : base(messenger)
        {
            _mainMenuViewModel = mainMenuViewModel;
            _topBarViewModel = topBarViewModel;
            _userPanelViewModel = userPanelViewModel;
            _overviewViewModel = overviewViewModel;
            _animeInfoViewModel = animeInfoViewModel;
            _settingsViewModel = settingsViewModel;
            _aboutAppViewModel = aboutAppViewModel;

            MainMenuViewModel = _mainMenuViewModel;
            TopBarViewModel = _topBarViewModel;
            UserPanelViewModel = _userPanelViewModel;

            CurrentContentViewModel = _overviewViewModel;
            PreviousContentViewModel = CurrentContentViewModel;

            _messenger.RegisterAll(this);
        }

        public void Receive(SwitchContentView message)
        {
            ContentTypes contentType = message.contentType;
            PreviousContentViewModel = CurrentContentViewModel;

            switch(contentType)
            {
                case (ContentTypes.OVERVIEW):
                    CurrentContentViewModel = _overviewViewModel;
                    break;
                case (ContentTypes.ANIMELIST):
                    CurrentContentViewModel = _animeInfoViewModel;
                    break;
                case (ContentTypes.SETTINGS):
                    CurrentContentViewModel = _settingsViewModel;
                    break;
                case (ContentTypes.ABOUT):
                    CurrentContentViewModel = _aboutAppViewModel;
                    break;
            }
        }
    }
}
