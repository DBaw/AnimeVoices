using AnimeVoices.DataAccess.Repositories;
using AnimeVoices.Models;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels.Content.InfoPanels
{
    public partial class AnimeInfoPanelViewModel : BaseViewModel, IRecipient<SelectedAnimeChanged>
    {
        private readonly IAnimeRepository _animeRepository;

        [ObservableProperty] Anime? _selectedAnime;

        public AnimeInfoPanelViewModel(IMessenger messenger, IAnimeRepository animeRepository) : base(messenger)
        {
            _animeRepository = animeRepository;
            _messenger.RegisterAll(this);
        }

        public void Receive(SelectedAnimeChanged message)
        {
            try
            {
                // TODO: Get Anime By Id - Add method to anime repository
            }
            catch 
            {
                // Set anime to null or to message.anime
            }
            SelectedAnime = message.anime;
        }
    }
}
