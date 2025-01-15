namespace AnimeVoices.Models
{
    public class AnimePagination
    {
        public int Page { get; set; }
        public bool HasNextPage { get; set; }
        public string Properties { get; set; }

        public AnimePagination()
        {
            
        }
    }
}
