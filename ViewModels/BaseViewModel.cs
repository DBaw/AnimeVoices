using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        protected readonly IMessenger _messenger;

        protected BaseViewModel(IMessenger messenger)
        {
            _messenger = messenger;
        }
    }
}
