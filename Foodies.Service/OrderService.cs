using Foodies.Core;
using Foodies.Core.Entities;
using Foodies.Core.Entities.Order_Aggregate;
using Foodies.Core.IRepositories;
using Foodies.Core.IServices;
using Foodies.Core.Specifications.Order_Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Service
{
    public class OrderService : IOrderService
    {
        private readonly ICartRepository _cartRepo;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(
            ICartRepository cartRepo,
            IUnitOfWork unitOfWork)
        {
            _cartRepo = cartRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Order?> CreateOrderAsync(string buyerEmail, string cartId, int deliveryMethodId, Address address)
        {
            var cart = await _cartRepo.GetCartAsync(cartId);

            var orderItems = new List<OrderItem>();

            if (cart?.Items?.Count > 0)
            {
                var foodRepo = _unitOfWork.Repo<Food>();
                foreach (var item in cart.Items)
                {
                    var food = await foodRepo.GetAsync(item.Id);
                    if(food is null) continue;

                    var foodItem = new OrderItemFood(item.Id, food.Name, food.PictureUrl);

                    orderItems.Add(new OrderItem(foodItem, food.UnitPrice, item.Quantity));
                }
            }

            var subTotal = orderItems.Sum(OItem => OItem.Quantity * OItem.UnitPrice);

            var deliveryMethod = await _unitOfWork.Repo<DeliveryMethod>().GetAsync(deliveryMethodId);

            var order = new Order(buyerEmail, subTotal, deliveryMethod, address, orderItems);

            await _unitOfWork.Repo<Order>().AddAsync(order);

            var changes = await _unitOfWork.CompleteAsync();

            if (changes <= 0) return null;

            return order;
        }

        public async Task<Order?> GetOrderByIdforUserAsync(string buyerEmail, int orderId)
        {
            var spec = new OrderSpecifications(buyerEmail, orderId);
            var order = await _unitOfWork.Repo<Order>().GetWithSpecsAsync(spec);
            return order;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrderSpecifications(buyerEmail);
            var orders = await _unitOfWork.Repo<Order>().GetAllWithSpecsAsync(spec);
            return orders;
        }
    }
}
