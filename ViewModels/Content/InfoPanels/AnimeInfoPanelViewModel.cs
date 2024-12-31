using AnimeVoices.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AnimeVoices.ViewModels.Content.InfoPanels
{
    public partial class AnimeInfoPanelViewModel : ObservableObject
    {
        [ObservableProperty] Anime _selectedAnime;

        public AnimeInfoPanelViewModel(Anime anime)
        {
            SelectedAnime = anime;
        }
    }
}
