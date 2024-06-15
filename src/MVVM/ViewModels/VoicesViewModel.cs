using AnimeVoices.Core;
using AnimeVoices.Services;

namespace AnimeVoices.MVVM.ViewModels
{
    public class VoicesViewModel : BaseViewModel
    {
        public RelayCommand GoToHomeCommand { get; set; }

        public VoicesViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            GoToHomeCommand = new RelayCommand(o =>
            {
                GoToHomeView();
            });
        }

        private void GoToHomeView()
        {
            NavigationService.NavigateTo<HomeViewModel>();
        }
    }
}
