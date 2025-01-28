using AnimeVoices.Utilities;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels
{
    public partial class MainMenuViewModel : BaseViewModel
    {
        [ObservableProperty]
        private int _selectedItemIndex;

        public MainMenuViewModel(IMessenger messenger) : base(messenger)
        {
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
                    type = ContentTypes.GETMOREDATA;
                    break;
                case 2:
                    type = ContentTypes.ANIMELIST;
                    break;
            }
            _messenger.Send(new SwitchContentView(type));
        }
    }
}
