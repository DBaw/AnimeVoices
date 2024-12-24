using CommunityToolkit.Mvvm.ComponentModel;

namespace AnimeVoices.Utilities.Events
{
    public partial class SwitchContent : ObservableObject
    {
        [ObservableProperty]
        private ContentTypes _contentType;

        public SwitchContent(ContentTypes contentTypes){
            ContentType = contentTypes;
        }
    }
}
