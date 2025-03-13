using Foodies.Core.Entities;
using Foodies.Core.IRepositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Foodies.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly IDatabase _database;

        public CartRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }


        public async Task<bool> DeleteCartAsync(string cartId)
        {
            return await _database.KeyDeleteAsync(cartId);
        }

        public async Task<Cart?> GetCartAsync(string cartId)
        {
            var cart = await _database.StringGetAsync(cartId);

            return cart.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Cart>(cart);
        }

        public async Task<Cart?> UpdateCartAsync(Cart cart)
        {
            var result = await _database.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart), TimeSpan.FromDays(14));

            if (result is false)
                return null;

            return await GetCartAsync(cart.Id);
        }
    }
}
