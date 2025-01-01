using AnimeVoices.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AnimeVoices.ViewModels.Content.InfoPanels
{
    public partial class ResultInfoPanelViewModel : ObservableObject
    {
        [ObservableProperty] Character _selectedCharacter;
        [ObservableProperty] Result _result;

        public ResultInfoPanelViewModel(Character selectedCharacter, Result result)
        {
            SelectedCharacter = selectedCharacter;
            Result = result;
        }
    }
}
