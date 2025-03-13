using Foodies.APIs.Errors;
using Foodies.APIs.Extensions;
using Foodies.APIs.Helpers;
using Foodies.APIs.Middlewares;
using Foodies.Core.Entities.Identity;
using Foodies.Core.IRepositories;
using Foodies.Repository;
using Foodies.Repository.Data;
using Foodies.Repository.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;

namespace Foodies.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Services Container

            // Add services to the container.
            builder.Services.AddControllers();


            builder.Services.AddDbContext<AppDbContext>(config =>
            {
                config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<AppUserDbContext>(config =>
            {
                config.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddSingleton<IConnectionMultiplexer>(serviceProvider =>
            {
                return ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis"));
            });

            builder.Services.UseApplicationServices();

            builder.Services.AddSwaggerServices();

            builder.Services.AddAuthServices(builder.Configuration);

            #endregion


            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var dbContext = services.GetRequiredService<AppDbContext>();
            var identityDbContext = services.GetRequiredService<AppUserDbContext>();

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await dbContext.Database.MigrateAsync();
                await AppDbContextSeed.Seed(dbContext);

                await identityDbContext.Database.MigrateAsync();

                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                await AppUserDbContextSeed.SeedAsync(userManager);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error has occured");
            }

            #region Configuring Middlewares

            // Configure the HTTP request pipeline.

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddlewares();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers(); 

            #endregion


            app.Run();
        }
    }
}
