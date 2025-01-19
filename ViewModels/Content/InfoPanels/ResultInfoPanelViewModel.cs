using AnimeVoices.Models;
using AnimeVoices.Utilities.Events;
using AnimeVoices.Utilities.Helpers;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels.Content.InfoPanels
{
    public partial class ResultInfoPanelViewModel : BaseViewModel, IRecipient<SelectedResultChanged>
    {
        [ObservableProperty] Character? _selectedCharacter;
        [ObservableProperty] string? _resultCharacter;
        [ObservableProperty] Bitmap? _resultImage;

        public ResultInfoPanelViewModel(IMessenger messenger) : base(messenger)
        {
            _messenger.RegisterAll(this);
        }
        public async void Receive(SelectedResultChanged message)
        {
            if(ResultImage != null)
            {
                ResultImage.Dispose();
            }
            SelectedCharacter = message.character;
            ResultCharacter = message.result?.Character;
            ResultImage = await ImageHelper.LoadImage(message.result?.ImageUrl);
        }
    }
}
