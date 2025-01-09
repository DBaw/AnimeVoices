using AnimeVoices.Models;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.IO;
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

                // Logging addition
                File.AppendAllText("log_seiyuu_count.txt", "Added to store: " + SeiyuuCollection.Count + "\n");

                // Send update message
                _messenger.Send(new SeiyuuCollectionChanged(SeiyuuCollection.Count));
                File.AppendAllText("log_seiyuu_count.txt", "Message sent\n");
            }
        }

        public void Remove(int id)
        {
            var seiyuu = SeiyuuCollection.FirstOrDefault(s => s.Id == id);
            if (seiyuu != null)
            {
                SeiyuuCollection.Remove(seiyuu);

                // Logging removal
                File.AppendAllText("log_seiyuu_count.txt", "Removed from store: " + id + "\n");

                // Send update message
                _messenger.Send(new SeiyuuCollectionChanged(SeiyuuCollection.Count));
                File.AppendAllText("log_seiyuu_count.txt", "Message sent\n");
            }
        }

        public void Update(Seiyuu seiyuu)
        {
            var existing = SeiyuuCollection.FirstOrDefault(s => s.Id == seiyuu.Id);
            if (existing != null)
            {
                // Replace the existing seiyuu
                SeiyuuCollection.Remove(existing);
                SeiyuuCollection.Add(seiyuu);

                // Logging update
                File.AppendAllText("log_seiyuu_count.txt", "Updated in store: " + seiyuu.Id + "\n");

                // Send update message
                _messenger.Send(new SeiyuuCollectionChanged(SeiyuuCollection.Count));
                File.AppendAllText("log_seiyuu_count.txt", "Message sent\n");
            }
        }

        public int CountCollection()
        {
            return SeiyuuCollection.Count;
        }
    }
}
