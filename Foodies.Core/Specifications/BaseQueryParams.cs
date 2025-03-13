using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Specifications
{
    public class BaseQueryParams
    {
        public string? Search { get; set; }

        public string? Sort { get; set; }


        private const int MaxPageSize = 10;
        public int PageIndex { get; set; } = 1;

        private int pageSize = 5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value <= MaxPageSize ? value : MaxPageSize; }
        }

        public void MaxPageIndex(int count)
        {
            int LatestPage = (int) Math.Ceiling((double)count / pageSize);

            if (PageIndex > LatestPage)
                PageIndex = LatestPage;
        }
    }
}
