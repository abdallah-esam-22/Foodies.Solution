using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Specifications.Vendor_Specs
{
    public class VendorQueryParams : BaseQueryParams
    {
        public int? MinRating { get; set; }
    }
}
