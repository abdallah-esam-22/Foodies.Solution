using Foodies.Core.Entities;
using Foodies.Core.Specifications.Food_Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Specifications.Food_Specs
{
    public class FoodsCountSpec : BaseSpecs<Food>
    {
        public FoodsCountSpec(FoodQueryParams queryParams) 
            : base(
                    F => (!queryParams.VendorId.HasValue || F.VendorId == queryParams.VendorId) &&
                        (!queryParams.CategoryId.HasValue || F.CategoryId == queryParams.CategoryId)
                  )
        {
        }
    }
}
