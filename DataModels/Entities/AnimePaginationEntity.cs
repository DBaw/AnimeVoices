using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DataModels.Entities
{
    public class AnimePaginationEntity
    {
        [Key]
        public string Properties { get; set; }

        public int Page { get; set; }

        public bool HasNextPage { get; set; }

        public AnimePaginationEntity()
        {
            
        }

    }
}
