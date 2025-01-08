using AnimeVoices.Models;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnimeVoices.Stores
{
    public class CharacterStore
    {
        private readonly IMessenger _messenger;

        public ObservableCollection<Character> CharacterCollection { get; }

        public CharacterStore(IMessenger messenger)
        {
            CharacterCollection = new();
            _messenger = messenger;

            CharacterCollection.CollectionChanged += (s, e) =>
            {
                _messenger.Send(new CharacterCollectionChanged(CharacterCollection.Count));
            };
        }

        public void Add(Character character)
        {
            if (!CharacterCollection.Any(c => c.Id == character.Id))
                CharacterCollection.Add(character);
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
    }
}
