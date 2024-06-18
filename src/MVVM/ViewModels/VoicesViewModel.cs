using AnimeVoices.Core;
using AnimeVoices.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AnimeVoices.MVVM.ViewModels
{
    public class VoicesViewModel : BaseViewModel
    {
        private readonly IAnimeRepository _animeRepository;

        public RelayCommand GoToHomeCommand { get; set; }
        public RelayCommandParam<Anime> SelectAnimeCommand { get; set; }
        public RelayCommandParam<Character> SelectCharacterCommand { get; set; }
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

        private ObservableCollection<Character> _characters;
        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set
            {
                if (_characters != value)
                {
                    _characters = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Character> _sameCharacters;
        public ObservableCollection<Character> SameCharacters
        {
            get { return _sameCharacters; }
            set 
            {
                _sameCharacters = value;
                OnPropertyChanged();
            }
        }


        public VoicesViewModel(INavigationService navigationService, IAnimeRepository animeRepository)
        {
            NavigationService = navigationService;
            _animeRepository = animeRepository;

            GoToHomeCommand = new RelayCommand(o =>
            {
                GoToHomeView();
            });

            SelectAnimeCommand = new RelayCommandParam<Anime>(SelectCharacters);

            Animes = new ObservableCollection<Anime>
            {
                new Anime(0, "Naruto", new List<Character>(){new Character("Naruto"),new Character("Sasuke")} ),
                new Anime(1, "Bleach", new List<Character>(){new Character("Ichigo"),new Character("Rukia"),new Character("Ishida")} ),
                new Anime(2, "Dragon Ball", new List<Character>(){new Character("Goku"),new Character("Vegeta")} ),
                new Anime(3, "Kimetsu No Yaiba", new List<Character>(){new Character("Tanjiro"),new Character("Nezuko")} ),
                new Anime(4, "Noragami", new List<Character>(){new Character("Yato"),new Character("Yukine"), new Character("Hiyori") } ),
                new Anime(5, "One Piece", new List<Character>(){new Character("Luffy")} ),
                new Anime(6, "Boku No Hero Academia", new List<Character>(){new Character("Midorya"),new Character("Bakugo"), new Character("All For One"), new Character("Uraraka") } ),
                new Anime(7, "Kaiju No 8", new List<Character>(){new Character("Kafka"),new Character("Mina"), new Character("Reno") } ),
                new Anime(8, "Solo Leveling", new List<Character>(){new Character("Sung")} ),
                new Anime(9, "Death Note", new List<Character>(){new Character("Yagami Light"),new Character("L")} ),
                new Anime(10, "Dragon Ball Z", new List<Character>(){new Character("Goku"),new Character("Vegeta")} ),
                new Anime(11, "Boruto", new List<Character>(){ new Character("Boruto"), new Character("Naruto"),new Character("Sasuke")} ),
                new Anime(12, "Hellsing", new List < Character >() { new Character("Allucard"), new Character("Integra") }),
                new Anime(13, "One-Punch Man", new List < Character >() { new Character("Saitama"), new Character("Genos") }),
                new Anime(14, "Tokyo Ghul", new List < Character >() { new Character("Kaneki"), new Character("Touka"), new Character("Amon") }),
                new Anime(15, "Mashle", new List < Character >() { new Character("Mashle"), new Character("Lemon") }),
            };
            Characters = new ObservableCollection<Character>();
            Debug = "debug";
        }

        private void GoToHomeView()
        {
            NavigationService.NavigateTo<HomeViewModel>();
        }

        private void SelectCharacters(Anime selectedAnime)
        {
            Characters.Clear();
            foreach(Anime anime in Animes)
            {
                if(selectedAnime.Title == anime.Title)
                {
                    Characters = new ObservableCollection<Character>(anime.Characters);
                    break;
                }
            }
        }
    }
}
