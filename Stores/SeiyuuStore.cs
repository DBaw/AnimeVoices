using AnimeVoices.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnimeVoices.Stores
{
    public class SeiyuuStore
    {
        public ObservableCollection<Seiyuu> CharacterCollection { get; }

        public SeiyuuStore()
        {
            CharacterCollection = new();
        }

        public void Add(Seiyuu seiyuu)
        {
            if (!CharacterCollection.Any(s => s.Id == seiyuu.Id))
                CharacterCollection.Add(seiyuu);
        }

        public void Remove(int Id)
        {
            var seiyuu = CharacterCollection.First(s => s.Id == Id);
            if (seiyuu != null)
                CharacterCollection.Remove(seiyuu);
        }

        public void Update(Seiyuu seiyuu)
        {
            var existing = CharacterCollection.First(s => s.Id == seiyuu.Id);
            if (existing != null)
            {
                CharacterCollection.Remove(existing);
                CharacterCollection.Add(seiyuu);
            }
        }
    }
}
