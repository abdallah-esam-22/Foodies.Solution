using Foodies.Core.Entities.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.IServices
{
    public interface IOrderService
    {
        Task<Order?> CreateOrderAsync(string buyerEmail, string cartId, int deliveryMethodId, Address address);

        Task<Order?> GetOrderByIdforUserAsync(string buyerEmail, int orderId);

        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
    }
}
