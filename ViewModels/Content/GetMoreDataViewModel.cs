using AnimeVoices.ViewModels.Content.MoreData;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AnimeVoices.ViewModels.Content
{
    public partial class GetMoreDataViewModel : BaseViewModel
    {
        private readonly GetSingleDataViewModel _getSingleDataViewModel;
        private readonly GetTopDataViewModel _getTopDataViewModel;

        [ObservableProperty]
        BaseViewModel _getSingleDataView;
        [ObservableProperty]
        BaseViewModel _getTopDataView;

        public GetMoreDataViewModel(IMessenger messenger, GetSingleDataViewModel getSingleDataViewModel, GetTopDataViewModel getTopDataViewModel) : base(messenger)
        {
            _getSingleDataViewModel = getSingleDataViewModel;
            _getTopDataViewModel = getTopDataViewModel;

            GetSingleDataView = _getSingleDataViewModel;
            GetTopDataView = _getTopDataViewModel;
        }
    }
}
