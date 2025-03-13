using Foodies.Core.Entities.IEntities;

namespace Foodies.Core.Entities.Order_Aggregate
{
    public class OrderItemFood : IPicturable
    {
        public OrderItemFood()
        {
            
        }
        public OrderItemFood(int foodId, string foodName, string pictureUrl)
        {
            FoodId = foodId;
            FoodName = foodName;
            PictureUrl = pictureUrl;
        }

        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string PictureUrl { get; set; }
    }
}