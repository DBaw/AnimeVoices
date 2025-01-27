using AnimeVoices.DataAccess.Repositories;
using AnimeVoices.Models;
using AnimeVoices.Stores;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeVoices.ViewModels.Content.MoreData
{
    public partial class GetSingleDataViewModel : BaseViewModel, IRecipient<CanGetMoreDataEvent>
    {
        [ObservableProperty] public string? _animeIdText;
        [ObservableProperty] public string? _animeCheckText;
        [ObservableProperty] public bool _canGetData;

        private int _animeId;
        private bool _parsed;
        private readonly IAnimeRepository _animeRepository;
        private readonly AnimeStore _animeStore;

        public GetSingleDataViewModel(IMessenger messenger, IAnimeRepository animeRepository, AnimeStore animeStore) : base(messenger) 
        {
            _messenger.RegisterAll(this);

            _animeRepository = animeRepository;
            _animeStore = animeStore;
            
            CanGetData = true;
        }

        [RelayCommand(CanExecute = "CheckIfCanGetData")]
        public async Task GetData()
        {
            bool alreadyExists = _animeStore.AnimeCollection.Any(a => a.Id == _animeId);
            _messenger.Send(new CanGetMoreDataEvent(false));
            await _animeRepository.GetAnimeByIdAsync(_animeId);
            await Task.Delay(1000);
            Anime? anime = _animeStore.AnimeCollection.FirstOrDefault(a => a.Id == _animeId);

            string message = string.Empty;
            if(anime != null)
            {
                message = anime.Title;
                if (alreadyExists)
                {
                    message += " updated";
                }
                else
                {
                    message += " added";
                }
            } 
            else
            {
                message = "Anime doesn't exist";
            }
            AnimeCheckText = message;

            _messenger.Send(new CanGetMoreDataEvent(true));
        }
        private bool CheckIfCanGetData()
        {
            if (!_parsed && !string.IsNullOrEmpty(AnimeIdText))
            {
                AnimeCheckText = "ID must me a number";
            } 
            return _parsed && CanGetData;
        }

        partial void OnAnimeIdTextChanged(string? value)
        {
            AnimeCheckText = "";
            _parsed = int.TryParse(AnimeIdText, out _animeId);
            GetDataCommand.NotifyCanExecuteChanged();
        }

        public void Receive(CanGetMoreDataEvent message)
        {
            CanGetData = message.canGetData;
            GetDataCommand.NotifyCanExecuteChanged();
        }
    }
}
