using AnimeVoices.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AnimeVoices.ViewModels.Content.InfoPanels
{
    public partial class CharacterInfoPanelViewModel : ObservableObject
    {
        [ObservableProperty] Character _character;
        [ObservableProperty] Seiyuu _seiyuu;

        public CharacterInfoPanelViewModel(Character character, Seiyuu seiyuu)
        {
            Character = character;
            Seiyuu = seiyuu;
        }
    }
}
