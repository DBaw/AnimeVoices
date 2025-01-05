using AnimeVoices.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnimeVoices.Stores
{
    public class AnimeStore
    {
        public ObservableCollection<Anime> AnimeCollection { get; }

        public AnimeStore()
        {
            AnimeCollection = new();
        }

        public void Add(Anime anime)
        {
            if (!AnimeCollection.Any(a => a.Id == anime.Id))
                AnimeCollection.Add(anime);
        }

        public void Remove(int Id)
        {
            var anime = AnimeCollection.First(a => a.Id == Id);
            if (anime != null)
                AnimeCollection.Remove(anime);
        }

        public void Update(Anime anime)
        {
            var existing = AnimeCollection.First(a => a.Id == anime.Id);
            if (existing != null)
            {
                AnimeCollection.Remove(existing);
                AnimeCollection.Add(anime);
            }
        }
    }
}
