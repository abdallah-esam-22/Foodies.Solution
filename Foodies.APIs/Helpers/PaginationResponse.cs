using System.Drawing.Printing;

namespace Foodies.APIs.Helpers
{
    public class PaginationResponse<T> 
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }

        public PaginationResponse(int pageSize, int pageIndex, IReadOnlyList<T> data, int count)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Data = data;
            Count = count;
        }
    }
}
