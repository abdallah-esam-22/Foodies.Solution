using Foodies.Core.Entities;
using Foodies.Core.Entities.Order_Aggregate;
using Foodies.Core.Specifications.Food_Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.Specifications.Order_Specs
{
    public class OrderSpecifications : BaseSpecs<Order>
    {
        public OrderSpecifications(string buyerEmail)
            : base(GetCriteria(buyerEmail))
        {
            Includes.Add(O => O.DeliveryMethod);

            AddOrderByDesc(O => O.OrderDate);

        }

        public OrderSpecifications(string buyerEmail, int orderId)
            : base(GetCriteria(buyerEmail, orderId))
        {
            Includes.Add(O => O.DeliveryMethod);
            Includes.Add(O => O.OrderItems);
        }

        public static Expression<Func<Order, bool>> GetCriteria(string email, int? orderId = null)
        {
            return O => (O.BuyerEmail == email) &&
                        (!orderId.HasValue || O.Id == orderId);
        }
    }
}
