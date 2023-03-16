using LootManagerApi.Dto;
using LootManagerApi.Repositories.Interfaces;
using LootManagerApi.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> CheckUserLoginDtoAsync(UserLoginDto userLoginDto)
        {
            if (!UtilsEmail.IsValidateEmailAddressAttribute(userLoginDto.Email))
            {
                throw new Exception($"Invalid email address attribute : { userLoginDto.Email }");
            }
            if (!await UtilsEmail.IsEmailExistInContextAsync(userLoginDto.Email, context))
            {
                throw new Exception(userLoginDto.Email);
            }
            var passwordHash = await context.Users.Where(u => u.Email == userLoginDto.Email).Select(p => p.PasswordHash).FirstOrDefaultAsync();
            if (passwordHash == null)
            {
                throw new Exception("The hash search was unsuccessful.");
            }
            if (!UtilsPassword.CheckPasswordMatchesHash(userLoginDto.Password, passwordHash))
            {
                throw new Exception("The password is invalid.");
            }
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
