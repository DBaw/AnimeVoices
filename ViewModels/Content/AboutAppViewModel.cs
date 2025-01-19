using AnimeVoices.Utilities;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels.Content
{
    public partial class AboutAppViewModel : BaseViewModel
    {
        public AboutAppViewModel(IMessenger messenger) : base(messenger) { }

        [RelayCommand]
        public void GoBack()
        {
            _messenger.Send(new SwitchContentView(ContentTypes.PREVIOUS));
        }
    }
}
