using AnimeVoices.Models;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnimeVoices.Stores
{
    public class AnimeStore
    {
        private IMessenger _messenger { get; }

        public ObservableCollection<Anime> AnimeCollection { get; }
        public ObservableCollection<Anime> FilteredAnimeCollection { get; }

        public AnimeStore(IMessenger messenger)
        {
            _messenger = messenger;

            AnimeCollection = new();
            FilteredAnimeCollection = new();
        }

        public void Add(Anime anime)
        {
            if (!AnimeCollection.Any(a => a.Id == anime.Id))
            {
                AnimeCollection.Add(anime);
                _messenger.Send(new AnimeCollectionChanged(AnimeCollection.Count));
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
                _messenger.Send(new AnimeCollectionChanged(AnimeCollection.Count));
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
