using Foodies.Core.Entities;
using Foodies.Core.Entities.Order_Aggregate;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Foodies.Repository.Data
{
    public static class AppDbContextSeed
    {
        public static async Task Seed(AppDbContext dbContext)
        {
            if (!dbContext.Categories.Any())
            {
                var categoriesData = await File.ReadAllTextAsync("../Foodies.Repository/Data/Data Seeding/categories.json");
                var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

                if (!categories.IsNullOrEmpty())
                {
                    foreach (var category in categories)
                    {
                        dbContext.Categories.Add(category);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Vendors.Any())
            {
                var vendorsData = await File.ReadAllTextAsync("../Foodies.Repository/Data/Data Seeding/vendors.json");
                var vendors = JsonSerializer.Deserialize<List<Vendor>>(vendorsData);

                if (!vendors.IsNullOrEmpty())
                {
                    foreach (var vendor in vendors)
                    {
                        dbContext.Vendors.Add(vendor);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Foods.Any())
            {
                var foodsData = await File.ReadAllTextAsync("../Foodies.Repository/Data/Data Seeding/foods.json");
                var foods = JsonSerializer.Deserialize<List<Food>>(foodsData);

                if (!foodsData.IsNullOrEmpty())
                {
                    foreach (var food in foods)
                    {
                        dbContext.Foods.Add(food);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.DeliveryMethods.Any())
            {
                var deliveryMethodsData = File.ReadAllText("../Foodies.Repository/Data/Data Seeding/delivery.json");
                var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryMethodsData);

                if (!deliveryMethods.IsNullOrEmpty())
                {
                    foreach (var item in deliveryMethods)
                    {
                        dbContext.DeliveryMethods.Add(item);
                    }

                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
