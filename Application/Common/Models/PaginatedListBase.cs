namespace Application.Common.Models
{
    public class PaginatedListBase
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 100;
    }
}