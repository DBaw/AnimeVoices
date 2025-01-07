using AnimeVoices.DataModels.DTOs;
using System.Collections.Generic;

namespace AnimeVoices.Stores
{
    public class SeiyuuDtoStore
    {
        private readonly Dictionary<int, SeiyuuDto> _store = new();

        public void Add(SeiyuuDto seiyuuDto)
        {
            if (!_store.ContainsKey(seiyuuDto.Id))
            {
                _store[seiyuuDto.Id] = seiyuuDto;
            }
        }

        public SeiyuuDto Get(int id) => _store.TryGetValue(id, out var seiyuuDto) ? seiyuuDto : null;

        public bool Contains(int id) => _store.ContainsKey(id);

        public void Clear() => _store.Clear();
    }
}
