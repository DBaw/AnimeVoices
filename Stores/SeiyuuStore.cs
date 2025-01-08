using AnimeVoices.Models;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnimeVoices.Stores
{
    public class SeiyuuStore
    {
        private readonly IMessenger _messenger;

        public ObservableCollection<Seiyuu> SeiyuuCollection { get; }

        public SeiyuuStore(IMessenger messenger)
        {
            SeiyuuCollection = new();
            _messenger = messenger;

            SeiyuuCollection.CollectionChanged += (s, e) =>
            {
                _messenger.Send(new SeiyuuCollectionChanged(SeiyuuCollection.Count));
            };
        }

        public void Add(Seiyuu seiyuu)
        {
            if (!SeiyuuCollection.Any(s => s.Id == seiyuu.Id))
                SeiyuuCollection.Add(seiyuu);
        }

        public void Remove(int Id)
        {
            var seiyuu = SeiyuuCollection.First(s => s.Id == Id);
            if (seiyuu != null)
                SeiyuuCollection.Remove(seiyuu);
        }

        public void Update(Seiyuu seiyuu)
        {
            var existing = SeiyuuCollection.First(s => s.Id == seiyuu.Id);
            if (existing != null)
            {
                SeiyuuCollection.Remove(existing);
                SeiyuuCollection.Add(seiyuu);
            }
        }

        public int CountCollection()
        {
            return SeiyuuCollection.Count;
        }
    }
}
