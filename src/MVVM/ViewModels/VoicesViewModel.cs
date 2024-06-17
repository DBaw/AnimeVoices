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


        private ObservableCollection<Anime> _aniems;
        public ObservableCollection<Anime> Animes
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

            Animes = new ObservableCollection<Anime>
            {
                new Anime("Naruto"),
                new Anime("Bleach"),
                new Anime("Dragon Ball"),
                new Anime("Kimetsu No Yaiba"),
                new Anime("Noragami"),
                new Anime("One Piece"),
                new Anime("Boku No Hero Academia"),
                new Anime("Kaiju No 8"),
                new Anime("Solo Leveling"),
                new Anime("Death Note"),
                new Anime("Dragon Ball Z"),
                new Anime("Boruto"),
                new Anime("Hellsing"),
                new Anime("One-Punch Man"),
                new Anime("Tokyo Ghul"),
                new Anime("Mashle"),
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
