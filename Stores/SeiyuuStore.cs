using AnimeVoices.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnimeVoices.Stores
{
    public class SeiyuuStore
    {
        public ObservableCollection<Seiyuu> SeiyuuCollection { get; }

        public SeiyuuStore()
        {
            SeiyuuCollection = new();
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
