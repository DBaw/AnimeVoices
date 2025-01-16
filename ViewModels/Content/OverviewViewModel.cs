using AnimeVoices.DataAccess.Repositories;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Threading.Tasks;

namespace AnimeVoices.ViewModels.Content
{
    public partial class OverviewViewModel : BaseViewModel, IRecipient<AnimeCollectionChanged>, IRecipient<CharacterCollectionChanged>, IRecipient<SeiyuuCollectionChanged>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly ISeiyuuRepository _seiyuuRepository;

        [ObservableProperty]
        private bool _canGetMoreData;

        [ObservableProperty] private int _animeCount;
        [ObservableProperty] private int _characterCount;
        [ObservableProperty] private int _seiyuuCount;

        public OverviewViewModel(IMessenger messenger, IAnimeRepository animeRepository, ICharacterRepository characterRepository, ISeiyuuRepository seiyuuRepository) : base(messenger)
        {
            _messenger.RegisterAll(this);

            _animeRepository = animeRepository;
            _characterRepository = characterRepository;
            _seiyuuRepository = seiyuuRepository;

            _animeRepository.InitializeAsync();
            _characterRepository.InitializeAsync();
            _seiyuuRepository.InitializeAsync();

            CanGetMoreData = true;
        }

        [RelayCommand]
        public async Task GetMoreData()
        {
            CanGetMoreData = false;
            await _animeRepository.GetTopAnimeAsync();
            await Task.Delay(1000);
            CanGetMoreData = true;
        }

        public void Receive(AnimeCollectionChanged message)
        {
            AnimeCount = message.NewCount;
        }

        public void Receive(CharacterCollectionChanged message)
        {
            CharacterCount = message.NewCount;
        }

        public void Receive(SeiyuuCollectionChanged message)
        {
            SeiyuuCount = message.NewCount;
        }


    }
}
