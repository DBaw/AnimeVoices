using AnimeVoices.DataModels.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeVoices.DB
{
    public interface IAppDatabase
    {
        Task<List<AnimeEntity>> GetAllAnimeAsync();
        Task SaveAnimeAsync(AnimeEntity anime);

        Task<List<CharacterEntity>> GetAllCharactersAsync();
        Task SaveCharacterAsync(CharacterEntity character);

        Task<List<SeiyuuEntity>> GetAllSeiyuuAsync();
        Task SaveSeiyuuAsync(SeiyuuEntity seiyuu);

        Task<AnimePaginationEntity> GetTopAnimePagination(string properties);
        Task SaveAnimePaginationAsync(AnimePaginationEntity paginationEntity);

        List<AnimePaginationEntity> GetPaginations();
    }
}
