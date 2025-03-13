using AutoMapper;
using Foodies.APIs.DTOs.Food;
using Foodies.APIs.Errors;
using Foodies.APIs.Helpers;
using Foodies.Core;
using Foodies.Core.Entities;
using Foodies.Core.IRepositories;
using Foodies.Core.IServices;
using Foodies.Core.Specifications;
using Foodies.Core.Specifications.Food_Specs;
using Foodies.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodies.APIs.Controllers
{
    public class FoodsController : BaseAPIController
    {
        private readonly IMapper _mapper;
        private readonly IFoodService _foodService;

        public FoodsController(
            IMapper mapper,
            IFoodService foodService)
        {
            _mapper = mapper;
            _foodService = foodService;
        }


        [HttpGet]  // GET: api/foods
        public async Task<ActionResult<PaginationResponse<FoodDTO>>> GetFoods([FromQuery]FoodQueryParams queryParams)
        {
            var count = await _foodService.GetCountAsync(queryParams);

            queryParams.MaxPageIndex(count);

            var foods = await _foodService.GetFoodsAsync(queryParams);

            var data = _mapper.Map<IReadOnlyList<Food>, IReadOnlyList<FoodDTO>>(foods);

            var response = new PaginationResponse<FoodDTO>(queryParams.PageSize, queryParams.PageIndex, data, count);
            
            return Ok(response);
        }


        [ProducesResponseType(typeof(FoodDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]  // GET : api/foods/{id}
        public async Task<ActionResult<FoodDTO>> GetFoodById(int id)
        {
            var food = await _foodService.GetFoodByIdAsync(id);

            if (food is null)
                return NotFound(new BaseErrorApiResponse(404));

            return Ok(_mapper.Map<Food, FoodDTO>(food));
        }


        [HttpGet("categories")]  // GET: api/foods/categories
        public async Task<ActionResult<IReadOnlyList<CategoryDTO>>> GetCategories()
        {
            var categories = await _foodService.GetCategoriesAsync();
            return Ok(_mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryDTO>>(categories));
        }
    }
}
