using LootManagerApi.Dto;
using LootManagerApi.Repositories.Interfaces;
using LootManagerApi.Utils;
using LootManagerApi.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace LootManagerApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region DECLARATIONS
        LootManagerContext context;
        ILogger<UserRepository> logger;
        #endregion

        #region CONSTRUCTOR
        public UserRepository(LootManagerContext context, ILogger<UserRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        #endregion

        #region LOG
        public async Task<bool> CheckUserLoginDtoAsync(UserLoginDto userLoginDto)
        {
            if (!UtilsEmail.IsValidateEmailAddressAttribute(userLoginDto.Email))
            {
                throw new Exception($"Invalid email address attribute : {userLoginDto.Email}");
            }
            if (!await UtilsEmail.IsEmailExistInContextAsync(userLoginDto.Email, context))
            {
                throw new Exception($"Email does not exist : {userLoginDto.Email}");
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


        public async Task<ClaimsIdentity?> GetClaimsIdentityAsync(UserLoginDto userLoginDto)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == userLoginDto.Email);
                ClaimsIdentity identity = new(new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, user.FullName),
                    new(ClaimTypes.Email, user.Email)
                },
                CookieAuthenticationDefaults.AuthenticationScheme);
                Console.WriteLine("stop");
                return identity;
            }
            catch (Exception ex)
            {
                logger.LogError(ex?.InnerException.ToString());
                return null;
            }
        }
        #endregion

        #region GET
        public async Task<List<UserSummaryDto>> GetAllUsersAsync()
        {
            return await context.Users.Select(u => new UserSummaryDto(u)).ToListAsync();
        }
        #endregion

        #region POST
        public async Task<UserSummaryDto?> CreateUserAsync(UserCreateDto userCreateDto)
        {
            var user = new User(userCreateDto);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return new UserSummaryDto(user);
        }
        #endregion
    }
}
