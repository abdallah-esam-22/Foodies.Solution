using AutoMapper;
using Foodies.APIs.DTOs.Cart;
using Foodies.APIs.Errors;
using Foodies.Core.Entities;
using Foodies.Core.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodies.APIs.Controllers
{
    public class CartController : BaseAPIController
    {
        private readonly ICartRepository _cartRepo;
        private readonly IMapper _mapper;

        public CartController(ICartRepository cartRepo, IMapper mapper)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> UpdateCart(CartDTO model)
        {
            var mappedCart = _mapper.Map<CartDTO, Cart>(model);
            var cart = await _cartRepo.UpdateCartAsync(mappedCart);

            if (cart is null)
                return BadRequest(new BaseErrorApiResponse(400));

            return Ok(cart);
        }

        [HttpGet]
        public async Task<ActionResult<Cart>> GetCart(string id)
        {
            var cart = await _cartRepo.GetCartAsync(id);

            return Ok(cart ?? new Cart(id));
        }

        [HttpDelete]
        public async Task DeleteCart(string id)
        {
            await _cartRepo.DeleteCartAsync(id);
        }
    }
}
