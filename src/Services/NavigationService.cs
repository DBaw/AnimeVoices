using AnimeVoices.Core;
using AnimeVoices.MVVM.ViewModels;

namespace AnimeVoices.Services
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : BaseViewModel;
    }

    public class NavigationService : INavigationService
    {
        private MainViewModel _mainViewModel;

        public void SetMainViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            var viewModelInstance = ServiceLocator.Resolve<TViewModel>();
            viewModelInstance.NavigationService = this;
            _mainViewModel.CurrentView = viewModelInstance;
        }
    }
}
