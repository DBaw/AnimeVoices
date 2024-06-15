using AnimeVoices.Core;
using AnimeVoices.Services;

namespace AnimeVoices.MVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private object _currentView;
        private readonly INavigationService _navigationService;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            if (_navigationService is NavigationService ns)
            {
                ns.SetMainViewModel(this);
            }

            // Navigate to the initial view
            _navigationService.NavigateTo<HomeViewModel>();
        }
    }
}
