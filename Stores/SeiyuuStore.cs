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
        }

        public void Add(Seiyuu seiyuu)
        {
            if (!SeiyuuCollection.Any(s => s.Id == seiyuu.Id))
            {
                SeiyuuCollection.Add(seiyuu);
                _messenger.Send(new SeiyuuCollectionChanged(SeiyuuCollection.Count));
            }
        }

        public void Remove(int id)
        {
            var seiyuu = SeiyuuCollection.FirstOrDefault(s => s.Id == id);
            if (seiyuu != null)
            {
                SeiyuuCollection.Remove(seiyuu);
                _messenger.Send(new SeiyuuCollectionChanged(SeiyuuCollection.Count));
            }
        }

        public void Update(Seiyuu seiyuu)
        {
            var existing = SeiyuuCollection.FirstOrDefault(s => s.Id == seiyuu.Id);
            if (existing != null)
            {
                SeiyuuCollection.Remove(existing);
                SeiyuuCollection.Add(seiyuu);

                _messenger.Send(new SeiyuuCollectionChanged(SeiyuuCollection.Count));
            }
        }

        public int CountCollection()
        {
            return SeiyuuCollection.Count;
        }
    }
}
