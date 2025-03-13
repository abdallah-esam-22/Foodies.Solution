using Foodies.Core.Entities;
using Foodies.Core.Specifications.Food_Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.IServices
{
    public interface IFoodService
    {
        Task<IReadOnlyList<Food>> GetFoodsAsync(FoodQueryParams queryParams);

        Task<int> GetCountAsync(FoodQueryParams queryParams);

        Task<Food?> GetFoodByIdAsync(int id);

        Task<IReadOnlyList<Category>> GetCategoriesAsync();
    }
}
