using AnimeVoices.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnimeVoices.Stores
{
    public class CharacterStore
    {
        public ObservableCollection<Character> CharacterCollection { get; }
        public ObservableCollection<Character> FilteredCharacterCollection { get; }

        public CharacterStore()
        {
            CharacterCollection = new();
            FilteredCharacterCollection = new();
        }

        public void Add(Character character)
        {
            if (!CharacterCollection.Any(c => c.Id == character.Id))
                CharacterCollection.Add(character);
        }

        public void AddToFiltered(Character character)
        {
            if (!FilteredCharacterCollection.Any(c => c.Id == character.Id))
                FilteredCharacterCollection.Add(character);
        }

        public void Remove(int Id)
        {
            var character = CharacterCollection.First(c => c.Id == Id);
            if (character != null)
                CharacterCollection.Remove(character);
        }

        public void Update(Character character)
        {
            var existing = CharacterCollection.First(c => c.Id == character.Id);
            if (existing != null)
            {
                CharacterCollection.Remove(existing);
                CharacterCollection.Add(character);
            }
        }

        public int CountCollection()
        {
            return CharacterCollection.Count;
        }

        public void ClearFiltered()
        {
            FilteredCharacterCollection.Clear();
        }
    }
}
