using Foodies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Specifications.Food_Specs
{
    public class FoodWithCategoryAndVendorSpecs : BaseSpecs<Food>
    {
        public FoodWithCategoryAndVendorSpecs(FoodQueryParams queryParams)
            : base(GetCriteria(queryParams))
        {
            AddIncludes();

            ApplyPagination(queryParams.PageSize, queryParams.PageIndex);

            if (!string.IsNullOrEmpty(queryParams.Sort))
            {
                switch (queryParams.Sort)
                {
                    case "nameDesc":
                        AddOrderByDesc(F => F.Name);
                        break;
                    case "priceAsc":
                        AddOrderBy(F => F.UnitPrice);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(F => F.UnitPrice);
                        break;
                    default:
                        AddOrderBy(F => F.Name);
                        break;
                }
            }
            else
                AddOrderBy(F => F.Name);
        }

        public FoodWithCategoryAndVendorSpecs(int id) : base(F => F.Id == id)
        {
            AddIncludes();
        }

        public void AddIncludes()
        {
            Includes.Add(F => F.Category);
            Includes.Add(F => F.Vendor);
        }

        public static Expression<Func<Food, bool>> GetCriteria(FoodQueryParams Q)
        {
            return F => (!Q.VendorId.HasValue || F.VendorId == Q.VendorId) &&
                        (!Q.CategoryId.HasValue || F.CategoryId == Q.CategoryId) &&
                        (Q.Search == null || F.Name.ToLower().Contains(Q.Search.ToLower()));
        }
    }
}
