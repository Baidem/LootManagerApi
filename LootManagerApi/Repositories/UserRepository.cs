using LootManagerApi.Dto;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace LootManagerApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        LootManagerContext context;
        ILogger<UserRepository> logger;

        public UserRepository(LootManagerContext context, ILogger<UserRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool CheckUserLoginDto()
        {
            
            return true;
        }

        public ClaimsIdentity? GetClaimsIdentity(UserLoginDto userLoginDto)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.Email == userLoginDto.Email);
                ClaimsIdentity identity = new(new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, user.FullName),
                    new(ClaimTypes.Email, user.Email)
                },
                CookieAuthenticationDefaults.AuthenticationScheme);

                return identity;
            }
            catch (Exception ex)
            {
                logger.LogError(ex?.InnerException.ToString());
                return null;
            }
        }
    }
}
