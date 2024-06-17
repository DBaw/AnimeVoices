using AnimeVoices.Core;
using AnimeVoices.Services;
using System.Collections.ObjectModel;

namespace AnimeVoices.MVVM.ViewModels
{
    public class VoicesViewModel : BaseViewModel
    {
        public RelayCommand GoToHomeCommand { get; set; }
        public RelayCommand SelectAnimeCommand { get; set; }
        public string Debug {  get; set; }


        private ObservableCollection<string> _aniems;
        public ObservableCollection<string> Animes
        {
            get { return _aniems; }
            set
            {
                if (_aniems != value)
                {
                    _aniems = value;
                    OnPropertyChanged();
                }
            }
        }

        public VoicesViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            GoToHomeCommand = new RelayCommand(o =>
            {
                GoToHomeView();
            });

            SelectAnimeCommand = new RelayCommand(o => {
                SelectAnime();
            });

            Animes = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
            };
            Debug = "deug";
        }

        private void GoToHomeView()
        {
            NavigationService.NavigateTo<HomeViewModel>();
        }

        private void SelectAnime()
        {

        }
    }
}
