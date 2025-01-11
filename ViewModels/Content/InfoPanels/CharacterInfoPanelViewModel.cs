using AnimeVoices.Models;
using AnimeVoices.Utilities.Events;
using AnimeVoices.Utilities.Helpers;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels.Content.InfoPanels
{
    public partial class CharacterInfoPanelViewModel : BaseViewModel, IRecipient<SelectedCharacterChanged>
    {
        [ObservableProperty] public Character? _character;
        [ObservableProperty] public Seiyuu? _seiyuu;
        [ObservableProperty] public Bitmap? _characterImage;
        [ObservableProperty] public Bitmap? _seiyuuImage;


        public CharacterInfoPanelViewModel(IMessenger messenger) : base(messenger) 
        {
            _messenger.RegisterAll(this);
        }

        public void Receive(SelectedCharacterChanged message)
        {
            Character = message.character;
            Seiyuu = message.seiyuu;
            CharacterImage = ImageHelper.LoadImage(message.character?.ImageUrl.Trim()).Result;
            SeiyuuImage = ImageHelper.LoadImage(message.seiyuu?.ImageUrl.Trim()).Result;
        }
    }
}
