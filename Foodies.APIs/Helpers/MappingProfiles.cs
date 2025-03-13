using AutoMapper;
using Foodies.APIs.DTOs.Cart;
using Foodies.APIs.DTOs.Food;
using Foodies.APIs.DTOs.Order;
using Foodies.APIs.DTOs.User;
using Foodies.Core.Entities;
using Foodies.Core.Entities.Identity;
using Foodies.Core.Entities.Order_Aggregate;
using OrderAddress = Foodies.Core.Entities.Order_Aggregate.Address;
using IdentityAddress = Foodies.Core.Entities.Identity.Address;

namespace Foodies.APIs.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Food, FoodDTO>()
                .ForMember(d => d.Category, O => O.MapFrom(S => S.Category.Name))
                .ForMember(d => d.Vendor, O => O.MapFrom(S => S.Vendor.Name))
                .ForMember(d => d.PictureUrl, O => O.MapFrom<GenericPicUrlResolver<Food, FoodDTO>>());

            CreateMap<Category, CategoryDTO>()
                .ForMember(d => d.PictureUrl, O => O.MapFrom<GenericPicUrlResolver<Category, CategoryDTO>>());

            CreateMap<CartDTO, Cart>()
                .ForMember(D => D.Count, options => options.MapFrom(S => S.Items.Count));
            CreateMap<CartItemDTO, CartItem>();


            CreateMap<AddressDTO, OrderAddress>();

            CreateMap<Order, OrdersToReturnDTO>()
                .ForMember(D => D.DeliveryMethod, O => O.MapFrom(S => S.DeliveryMethod.ShortName));

            CreateMap<Order, OrderToReturnDTO>()
                .ForMember(D => D.DeliveryMethod, O => O.MapFrom(S => S.DeliveryMethod.ShortName))
                .ForMember(D => D.DeliveryMethodCost, O => O.MapFrom(S => S.DeliveryMethod.Cost));

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(D => D.FoodId, O => O.MapFrom(S => S.FoodItem.FoodId))
                .ForMember(D => D.FoodName, O => O.MapFrom(S => S.FoodItem.FoodName))
                .ForMember(D => D.PictureUrl, O => O.MapFrom<OrderItemPicURLResolver>());


            CreateMap<AppUser, UserProfileDTO>();
            CreateMap<IdentityAddress, AddressDTO>().ReverseMap();
        }
    }
}
