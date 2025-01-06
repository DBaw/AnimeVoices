using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels.Content
{
    public partial class WatchlistViewModel : BaseViewModel
    {
        public WatchlistViewModel(IMessenger messenger) : base(messenger) { }
    }
}
