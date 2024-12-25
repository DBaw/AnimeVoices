using CommunityToolkit.Mvvm.ComponentModel;

namespace AnimeVoices.Utilities.Events
{
    public partial class SwitchContentView : ObservableObject
    {
        [ObservableProperty]
        private ContentTypes _contentType;

        public SwitchContentView(ContentTypes contentTypes){
            ContentType = contentTypes;
        }
    }
}
