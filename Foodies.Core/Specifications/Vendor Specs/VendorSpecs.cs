using Foodies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Specifications.Vendor_Specs
{
    public class VendorSpecs : BaseSpecs<Vendor>
    {
        public VendorSpecs(VendorQueryParams queryParams) 
            : base(
                    V => (!queryParams.MinRating.HasValue || V.Rating >= queryParams.MinRating)
                  )
        {
            
            if (!string.IsNullOrEmpty(queryParams.Sort))
            {
                switch (queryParams.Sort)
                {
                    case "rating":
                        AddOrderByDesc(V => V.Rating);
                        break;
                    default:
                        AddOrderBy(V => V.Name);
                        break;
                }
            }
            else
                AddOrderBy(V => V.Name);
        }
    }
}
