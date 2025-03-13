using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Foodies.Core.Entities
{
    public class Cart
    {
        public string Id { get; set; }
        public List<CartItem> Items { get; set; }
        public int Count { get; set; }

        public Cart(string id)
        {
            Id = id;
            Items = new List<CartItem>();
        }
    }
}
