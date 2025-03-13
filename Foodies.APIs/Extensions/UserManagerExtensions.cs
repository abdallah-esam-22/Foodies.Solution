using Foodies.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Foodies.APIs.Extensions
{
    public static class UserManagerExtensions
    {
        public static Task<AppUser?> FindUserWithAddressAsync(this UserManager<AppUser> userManager, ClaimsPrincipal User)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = userManager.Users.Where(U => U.Email == email).Include(U => U.Address).SingleOrDefaultAsync();
            return user;
        }
    }
}
