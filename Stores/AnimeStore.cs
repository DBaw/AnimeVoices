using AnimeVoices.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnimeVoices.Stores
{
    public class AnimeStore
    {
        public ObservableCollection<Anime> AnimeCollection { get; }
        public ObservableCollection<Anime> FilteredAnimeCollection { get; }

        public AnimeStore()
        {
            AnimeCollection = new();
            FilteredAnimeCollection = new();
        }

        public void Add(Anime anime)
        {
            if (!AnimeCollection.Any(a => a.Id == anime.Id))
            {
                AnimeCollection.Add(anime);
            }
        }

        public void AddToFiltered(Anime anime)
        {
            if (!FilteredAnimeCollection.Any(a => a.Id == anime.Id))
            {
                FilteredAnimeCollection.Add(anime);
            }
        }

        public void Remove(int Id)
        {
            var anime = AnimeCollection.First(a => a.Id == Id);
            if (anime != null)
            {
                AnimeCollection.Remove(anime);
            }
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

        public int CountCollection()
        {
            return AnimeCollection.Count;
        }

        public void ClearFiltered()
        {
            FilteredAnimeCollection.Clear();
        }
    }
}
