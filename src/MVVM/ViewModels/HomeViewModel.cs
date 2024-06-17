using AnimeVoices.Core;
using AnimeVoices.Services;
using System.Collections.ObjectModel;

namespace AnimeVoices.MVVM.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public RelayCommand GoToVoicesCommand { get; set; }

        public HomeViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            GoToVoicesCommand = new RelayCommand(o =>
            {
                GoToVoicesView();
            });
        }

        private void GoToVoicesView()
        {
            NavigationService.NavigateTo<VoicesViewModel>();
        }

    }
}
