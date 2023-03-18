using LootManagerApi.Dto;
using LootManagerApi.Repositories.Interfaces;
using LootManagerApi.Utils;
using LootManagerApi.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Reflection.Metadata.Ecma335;

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


        public async Task<ClaimsIdentity> GetClaimsIdentityAsync(UserLoginDto userLoginDto)
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
                var message = ex?.InnerException.ToString();
                logger.LogError(message);
                throw new Exception(message);
            }
        }
        #endregion

        #region GET
        public async Task<List<UserSummaryDto>> GetAllUsersAsync()
        {
            return await context.Users.Select(u => new UserSummaryDto(u)).ToListAsync();
        }
        #endregion

        #region CREATE USER
        public async Task<UserSummaryDto?> CreateUserAsync(UserCreateDto userCreateDto)
        {
            var user = new User(userCreateDto);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return new UserSummaryDto(user);
        }
        public async Task<bool> IsValidUserCreateDtoAsync(UserCreateDto userCreateDto)
        {
            if (!UtilsEmail.IsValidateEmailAddressAttribute(userCreateDto.Email))
            {
                throw new Exception($"Invalid email address format : {userCreateDto.Email}");
            }
            if (await UtilsEmail.IsEmailExistInContextAsync(userCreateDto.Email, context))
            {
                throw new Exception(string.Format("Email does not exist : {0}", userCreateDto.Email));
            }
            int minLengthPassword = 8;
            if (UtilsPassword.CheckPasswordLength(userCreateDto.Password, minLengthPassword))
            {
                throw new Exception($"The password must have at least {minLengthPassword} characters.");
            }
            if (!UtilsPassword.CheckPasswordComplexity(userCreateDto.Password))
            {
                throw new Exception("The password must contain at least one upper case letter, one lower case letter, one number and one special character.");
            }
            return true;
        }



        #endregion

        #region UPDATE USER
        public async Task<UserSummaryDto> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => userUpdateDto.CurrentEmail == u.Email);
            if (user != null)
            {
                if (userUpdateDto.NewFullName == null && userUpdateDto.NewEmail == null && userUpdateDto.NewPassword == null)
                {
                    throw new Exception("No changes needed.");
                }
                if (userUpdateDto.NewFullName != null) { user.FullName = userUpdateDto.NewFullName; }
                if (userUpdateDto.NewEmail != null) { user.Email = userUpdateDto.NewEmail; }
                if (userUpdateDto.NewPassword != null) { user.PasswordHash = Utils.UtilsPassword.GenerateHashedPassword(userUpdateDto.NewPassword); }
                await context.SaveChangesAsync();
                return new UserSummaryDto(user);
            }
            throw new Exception("The user cannot be found.");
        }

        public async Task<bool> CheckUserUpdateDtoIsUserAuthentifiedAsync(UserUpdateDto userUpdateDto, UserAuthentifiedDto userAuthentifiedDto)
        {
            if (userUpdateDto.CurrentFullName == userAuthentifiedDto.FullName && userUpdateDto.CurrentEmail == userAuthentifiedDto.Email)
            {
                var passwordHash = await context.Users.Where(u => u.Email == userAuthentifiedDto.Email).Select(p => p.PasswordHash).FirstAsync();
                if (Utils.UtilsPassword.CheckPasswordMatchesHash(userUpdateDto.CurrentPassword, passwordHash))
                {
                    return true;
                }
            }
            throw new Exception("Data does not correspond to the current user.");
        }
        #endregion





    }
}
