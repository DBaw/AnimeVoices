using AnimeVoices.DataAccess.Repositories;
using AnimeVoices.Stores;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels.Content
{
    public partial class OverviewViewModel : BaseViewModel, IRecipient<AnimeCollectionChanged>, IRecipient<CharacterCollectionChanged>, IRecipient<SeiyuuCollectionChanged>
    {
        private readonly AnimeStore _animeStore;
        private readonly CharacterStore _characterStore;
        private readonly SeiyuuStore _seiyuuStore;
        private readonly IAnimeRepository _animeRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly ISeiyuuRepository _seiyuuRepository;

        [ObservableProperty]
        private bool _isApiWorking;

        [ObservableProperty] public int _animeCount;
        [ObservableProperty] public int _characterCount;
        [ObservableProperty] public int _seiyuuCount;

        public OverviewViewModel(IMessenger messenger, AnimeStore animeStore, CharacterStore characterStore, SeiyuuStore seiyuuStore, SeiyuuDtoStore seiyuuDtoStore, IAnimeRepository animeRepository, ICharacterRepository characterRepository, ISeiyuuRepository seiyuuRepository) : base(messenger)
        {
            _messenger.RegisterAll(this);

            _animeRepository = animeRepository;
            _characterRepository = characterRepository;
            _seiyuuRepository = seiyuuRepository;

            _animeStore = animeStore;
            _characterStore = characterStore;
            _seiyuuStore = seiyuuStore;

            //_animeRepository.InitializeAsync();
            //_characterRepository.InitializeAsync();
            //_seiyuuRepository.InitializeAsync();

            AnimeCount = _animeStore.CountCollection();
            CharacterCount = _characterStore.CountCollection();
            SeiyuuCount = _seiyuuStore.CountCollection();

            IsApiWorking = false;
        }

        [RelayCommand(CanExecute = "CanGetMoreData")]
        public async void GetMoreData()
        {
            IsApiWorking = true;

            await _animeRepository.GetTopAnimeAsync();
            /*await Task.Delay(100);

            foreach (Seiyuu seiyuu in seiyuuList)
            {
                SeiyuuDto dto = _seiyuuDtoStore.Get(seiyuu.Id);
                Task.WaitAll(_animeRepository.SaveAnimeFromSeiyuu(dto),
                              _characterRepository.SaveCharactersFromSeiyuu(dto));
            }

            _seiyuuDtoStore.Clear();

            await Task.Delay(25000);
            */
            IsApiWorking = false;
        }
        private bool CanGetMoreData() => !IsApiWorking;

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
