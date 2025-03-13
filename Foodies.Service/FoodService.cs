using Foodies.Core;
using Foodies.Core.Entities;
using Foodies.Core.IServices;
using Foodies.Core.Specifications.Food_Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Service
{
    public class FoodService : IFoodService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<Food>> GetFoodsAsync(FoodQueryParams queryParams)
        {
            var specs = new FoodWithCategoryAndVendorSpecs(queryParams);
            var foods = await _unitOfWork.Repo<Food>().GetAllWithSpecsAsync(specs);
            return foods;
        }

        public async Task<int> GetCountAsync(FoodQueryParams queryParams)
        {
            var specs = new FoodsCountSpec(queryParams);
            var count = await _unitOfWork.Repo<Food>().GetCountAsync(specs);
            return count;
        }

        public async Task<Food?> GetFoodByIdAsync(int id)
        {
            var specs = new FoodWithCategoryAndVendorSpecs(id);
            var food = await _unitOfWork.Repo<Food>().GetWithSpecsAsync(specs);
            return food;
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            var categories = await _unitOfWork.Repo<Category>().GetAllAsync();
            return categories;
        }
    }
}
