using AutoMapper;
using Foodies.APIs.DTOs.Order;
using Foodies.APIs.DTOs.User;
using Foodies.APIs.Errors;
using Foodies.Core.Entities.Order_Aggregate;
using Foodies.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Foodies.APIs.Controllers
{
    [Authorize]
    public class OrdersController : BaseAPIController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(
            IOrderService orderService,
            IMapper mapper
            )
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]  // POST: /api/orders
        public async Task<ActionResult<Order>> SubmitCart(OrderDTO order)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var mappedAddress = _mapper.Map<AddressDTO, Address>(order.Address);
            var createdOrder = await _orderService.CreateOrderAsync(email, order.CartId, order.DeliveryMethodId, mappedAddress);

            if (createdOrder is null) return BadRequest(new BaseErrorApiResponse(400));

            return Ok(createdOrder);
        }


        [HttpGet]  // GET: /api/orders
        public async Task<ActionResult<IReadOnlyList<OrdersToReturnDTO>>> GetOrders()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _orderService.GetOrdersForUserAsync(email);
            var mappedOrders = _mapper.Map<IReadOnlyList<OrdersToReturnDTO>>(orders);
            return Ok(mappedOrders);
        }


        [HttpGet("{Id}")]  // GET: /api/orders/{id}
        public async Task<ActionResult<Order>> GetOrder(int Id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var order = await _orderService.GetOrderByIdforUserAsync(email, Id);
            if (order is null) return NotFound(new BaseErrorApiResponse(404));

            var mappedOrder = _mapper.Map<OrderToReturnDTO>(order);
            return Ok(mappedOrder);
        }
    }
}
