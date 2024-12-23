using AnimeVoices.ViewModels.Content;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AnimeVoices.ViewModels
{

    public partial class MainWindowViewModel : ObservableObject
    {
        public ObservableObject MainMenuViewModel { get; set; }
        public ObservableObject UserPanelViewModel { get; set; }
        public ObservableObject TopBarViewModel { get; set; }

        [ObservableProperty]
        private ObservableObject _currentContentViewModel;

        public MainWindowViewModel()
        {
            MainMenuViewModel = new MainMenuViewModel();
            UserPanelViewModel = new UserPanelViewModel();
            TopBarViewModel = new TopBarViewModel();
            CurrentContentViewModel = new OverviewViewModel();
        }
    }
}
