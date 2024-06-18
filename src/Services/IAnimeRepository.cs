using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AnimeVoices.Services
{
    public interface IAnimeRepository
    {
        Task<ObservableCollection<Anime>> GetAnimesAsync();
    }
}
