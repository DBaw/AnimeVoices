using AnimeVoices.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AnimeVoices.Core
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public INavigationService NavigationService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
