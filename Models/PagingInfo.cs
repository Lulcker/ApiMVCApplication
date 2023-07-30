namespace ApiMVCApplication.Models
{
    public class PagingInfo
    {
        public int PageNumber { get; }

        public int TotalaPages { get; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalaPages;

        public PagingInfo(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalaPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
