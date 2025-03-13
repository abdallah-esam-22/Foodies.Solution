using Foodies.APIs.Errors;
using Foodies.APIs.Helpers;
using Foodies.APIs.Middlewares;
using Foodies.Core;
using Foodies.Core.IRepositories;
using Foodies.Core.IServices;
using Foodies.Repository;
using Foodies.Service;
using Microsoft.AspNetCore.Mvc;

namespace Foodies.APIs.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection UseApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();

            services.AddScoped<IFoodService, FoodService>();

            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICartRepository, CartRepository>();

            services.AddAutoMapper(typeof(MappingProfiles));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext =>
                {
                    var ErrorResponse = new ValidationErrorApiResponse()
                    {
                        Errors = actionContext.ModelState
                                    .Where(P => P.Value?.Errors.Count > 0)
                                    .ToDictionary(P => P.Key,
                                            P => P.Value.Errors.Select(E => E.ErrorMessage).ToList())
                    };

                    return new BadRequestObjectResult(ErrorResponse);
                });
            });

            services.AddScoped<ExceptionHandlerMiddleware>();

            return services;
        }
    }
}
