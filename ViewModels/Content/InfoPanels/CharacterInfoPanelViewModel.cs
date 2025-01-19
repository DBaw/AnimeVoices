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

        public async void Receive(SelectedCharacterChanged message)
        {
            if(CharacterImage != null)
            {
                CharacterImage.Dispose();
            }
            if (SeiyuuImage != null)
            {
                SeiyuuImage.Dispose();
            }
            Character = message.character;
            Seiyuu = message.seiyuu;
            CharacterImage = await ImageHelper.LoadImage(message.character?.ImageUrl?.Trim());
            SeiyuuImage = await ImageHelper.LoadImage(message.seiyuu?.ImageUrl?.Trim());
        }
    }
}
