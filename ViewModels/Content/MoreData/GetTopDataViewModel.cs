using AnimeVoices.DataAccess.Repositories;
using AnimeVoices.DataModels.Entities;
using AnimeVoices.DB;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeVoices.ViewModels.Content.MoreData
{
    public partial class GetTopDataViewModel : BaseViewModel, IRecipient<CanGetMoreDataEvent>
    {

        private readonly IAppDatabase _appDatabase;
        private readonly IAnimeRepository _animeRepository;

        private string _filter;
        private string _rating;

        [ObservableProperty] private string _pagesCounter;
        [ObservableProperty] private bool _canGetData;
        public string TopAnimeApiProperies => _filter + _rating;

        public GetTopDataViewModel(IMessenger messenger, IAppDatabase appDatabase, IAnimeRepository animeRepository) : base(messenger) 
        {
            _messenger.RegisterAll(this);

            _appDatabase = appDatabase;
            _animeRepository = animeRepository;
            _filter = "";
            _rating = "";

            PagesCounter = "";
            CanGetData = true;
        }

        [RelayCommand]
        public void ChangeFilter(string number)
        {
            int index = int.Parse(number);
            string prefix = "&filter=";
            
            _filter = index switch
            {
                0 => "",
                1 => prefix + "airing",
                2 => prefix + "upcoming",
                3 => prefix + "bypopularity",
                4 => prefix + "favorite"
            };
            OnPropertyChanged("TopApiProperies");
            RefreshDataCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand]
        public void ChangeRating(string number)
        {
            int index = int.Parse(number);
            string prefix = "&rating=";
            _rating = index switch
            {
                0 => "",
                1 => prefix + "pg",
                2 => prefix + "pg13",
                3 => prefix + "r17",
                _ => _filter
            };
            OnPropertyChanged("TopApiProperies");
            RefreshDataCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand(CanExecute = "CanRefreshData")]
        public async Task RefreshData()
        {
            List<AnimePaginationEntity> paginations = _appDatabase.GetPaginations();
            AnimePaginationEntity aP = paginations.Find(p => p.Properties == TopAnimeApiProperies);
            int pageCount = aP.Page;
            _messenger.Send(new CanGetMoreDataEvent(false));
            for (int i = 1; i <= pageCount; i++)
            {
                await _animeRepository.RefreshTopAnimeAsync(TopAnimeApiProperies, i);
                await Task.Delay(1000);
            }
            _messenger.Send(new CanGetMoreDataEvent(true));

        }
        private bool CanRefreshData()
        {
            if (!CanGetData)
            {
                return false;
            }
            List<AnimePaginationEntity> paginations = _appDatabase.GetPaginations();
            bool canRefresh = paginations.Any(p => p.Properties == TopAnimeApiProperies);
            DisplayPagesCounter(canRefresh, paginations);
            return canRefresh;
        }

        [RelayCommand]
        public async Task GetData()
        {
            _messenger.Send(new CanGetMoreDataEvent(false));
            await _animeRepository.GetTopAnimeAsync(TopAnimeApiProperies);
            await Task.Delay(1000);
            _messenger.Send(new CanGetMoreDataEvent(true));

            OnPropertyChanged("TopApiProperies");
        }

        public void Receive(CanGetMoreDataEvent message)
        {
            CanGetData = message.canGetData;
            RefreshDataCommand.NotifyCanExecuteChanged();
        }

        private void DisplayPagesCounter(bool canRefresh, List<AnimePaginationEntity> paginations)
        {
            if (canRefresh)
            {
                AnimePaginationEntity aP = paginations.Find(p => p.Properties == TopAnimeApiProperies);
                PagesCounter = aP.Page.ToString() + " page(s)";
            }
            else
            {
                PagesCounter = string.Empty;
            }
        }
    }
}
