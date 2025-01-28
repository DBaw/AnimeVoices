using AnimeVoices.DataAccess.Repositories;
using AnimeVoices.Models;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Threading.Tasks;

namespace AnimeVoices.ViewModels.Content.InfoPanels
{
    public partial class AnimeInfoPanelViewModel : BaseViewModel, IRecipient<SelectedAnimeChanged>, IRecipient<CanGetMoreDataEvent>
    {
        private readonly IAnimeRepository _animeRepository;

        [ObservableProperty] Anime? _selectedAnime;
        [ObservableProperty] private bool _canRefresh;

        public AnimeInfoPanelViewModel(IMessenger messenger, IAnimeRepository animeRepository) : base(messenger)
        {
            _messenger.RegisterAll(this);
            _animeRepository = animeRepository;

            CanRefresh = true;
        }

        [RelayCommand]
        public async Task GetAnimeInfo()
        {
            _messenger.Send(new CanGetMoreDataEvent(false));
            Anime anime = await _animeRepository.GetAnimeByIdAsync(SelectedAnime.Id);
            SelectedAnime = anime;
            await Task.Delay(1000);
            _messenger.Send(new CanGetMoreDataEvent(true));
        } 

        public void Receive(SelectedAnimeChanged message)
        {
            SelectedAnime = message.anime;
        }

        public void Receive(CanGetMoreDataEvent message)
        {
            CanRefresh = message.canGetData;
        }
    }
}
