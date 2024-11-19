namespace LogixApi_v02.ViewModels
{
    public class PaginationParams
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        // Additional properties
        public int Count { get; set; }
        //public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
    }
}
