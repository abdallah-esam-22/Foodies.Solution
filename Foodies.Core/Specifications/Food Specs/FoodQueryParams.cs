using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Specifications.Food_Specs
{
    public class FoodQueryParams : BaseQueryParams
    {
        public int? VendorId { get; set; }
        public int? CategoryId { get; set; }

    }
}
