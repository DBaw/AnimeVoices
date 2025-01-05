namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class PaginationDto
    {
        public int LastVisiblePage { get; set; }
        public bool HasNextPage { get; set; }
        public PaginationItemsDto Items { get; set; }
    }

    public class PaginationItemsDto
    {
        public int Count { get; set; }
        public int Total { get; set; }
        public int PerPage { get; set; }
    }
}
