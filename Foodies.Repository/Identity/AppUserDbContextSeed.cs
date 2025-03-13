using Foodies.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Repository.Identity
{
    public static class AppUserDbContextSeed
    {
        public async static Task SeedAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Ahmed Hamada",
                    UserName = "AhmedHamada",
                    Email = "ahmedhamada@Email.com",
                    PhoneNumber = "01122334455",
                    PasswordHash = "P@ssw0rd"
                };

                await userManager.CreateAsync(user, user.PasswordHash);
            }
        }
    }
}
