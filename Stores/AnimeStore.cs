﻿using AnimeVoices.Models;
using AnimeVoices.Utilities.Events;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnimeVoices.Stores
{
    public class AnimeStore
    {
        private readonly IMessenger _messenger;

        public ObservableCollection<Anime> AnimeCollection { get; }

        public AnimeStore(IMessenger messenger)
        {
            _messenger = messenger;
            
            AnimeCollection = new();

            AnimeCollection.CollectionChanged += (s, e) =>
            {
                _messenger.Send(new AnimeCollectionChanged(AnimeCollection.Count));
            };
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

        public int CountCollection()
        {
            return AnimeCollection.Count;
        }
    }
}
