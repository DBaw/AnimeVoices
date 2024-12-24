﻿using AnimeVoices.Utilities;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Threading.Tasks;

namespace AnimeVoices.ViewModels
{
    public partial class TopBarViewModel : ObservableObject
    {
        private IMessenger _messenger;

        public TopBarViewModel(IMessenger messenger)
        {
            _messenger = messenger;
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
            _messenger.Send(new SwitchContent(ContentTypes.SETTINGS));
        }
    }
}
