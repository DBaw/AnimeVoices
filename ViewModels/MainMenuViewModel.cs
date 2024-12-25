using AnimeVoices.Utilities;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels
{
    public partial class MainMenuViewModel : ObservableObject
    {
        private IMessenger _messenger;

        [ObservableProperty]
        private int _selectedItemIndex;

        public MainMenuViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            SelectedItemIndex = 0;
        }
        
        partial void OnSelectedItemIndexChanged(int value)
        {
            ContentTypes type = ContentTypes.OVERVIEW;
            switch (SelectedItemIndex)
            {
                case 0:
                    type = ContentTypes.OVERVIEW;
                    break;
                case 1:
                    type = ContentTypes.ANIMELIST;
                    break;
                case 2:
                    type = ContentTypes.FAVOURITES;
                    break;
                case 3:
                    type = ContentTypes.WATCHLIST;
                    break;
            }
            _messenger.Send(new SwitchContent(type));
        }
    }
}
