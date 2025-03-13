using Foodies.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Core.IServices
{
    public interface IAuthService
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
