using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities;
using LootManagerApi.Entities.logistics;
using LootManagerApi.Repositories.Interfaces;
using LootManagerApi.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Checks if the provided user login DTO is valid.
        /// </summary>
        /// <param name="userLoginDto">The user login DTO to check.</param>
        /// <returns>True if the user login DTO is valid, false otherwise.</returns>
        /// <exception cref="Exception">Thrown if the email address attribute is invalid, the email does not exist, the password hash search was unsuccessful, or the password is invalid.</exception>
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

        /// <summary>
        /// Gets the claims identity for a user based on their login information.
        /// </summary>
        /// <param name="userLoginDto">The user's login information.</param>
        /// <returns>A <see cref="ClaimsIdentity"/> object.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while getting the claims identity.</exception>
        public async Task<ClaimsIdentity> GetClaimsIdentityAsync(UserLoginDto userLoginDto)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == userLoginDto.Email);
                ClaimsIdentity identity = new(new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, user.FullName),
                    new(ClaimTypes.Email, user.Email),
                    new(ClaimTypes.Role, user.Role.ToString())
                },
                CookieAuthenticationDefaults.AuthenticationScheme);
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

        #region READ

        /// <summary>
        /// Retrieves a list of all user summary data asynchronously from the database.
        /// </summary>
        /// <returns>A list of UserSummaryDto objects containing summary data for all users.</returns>
        public async Task<List<UserSummaryDto>> GetAllUsersAsync()
        {
            var list = await context.Users.Select(u => new UserSummaryDto(u)).ToListAsync();
            if (list.Count == 0)
                throw new Exception("Empty list, no users are registered.");

            return list;
        }
        #endregion

        public async Task<UserDto> GetUserDto(int userId)
        {
            var userDto = await context.Users
                .Where(u => u.Id == userId)
                .Join(
                    context.DefaultLocations,
                    user => user.Id,
                    defaultLocation => defaultLocation.UserId,
                    (user, defaultLocation) => new UserDto(user, new DefaultLocationDto(defaultLocation))
                )
                .SingleOrDefaultAsync();

            if (userDto == null)
                throw new KeyNotFoundException("No user was found.");

            return userDto;
        }


        #region CREATE

        /// <summary>
        /// Create a User.
        /// </summary>
        /// <param name="user">User user</param>
        /// <returns>User</returns>
        public async Task<User> CreateUserAsync(User user)
        {
            await context.Users.AddAsync(user);

            await context.SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// Create a user with its main house and default location.
        /// </summary>
        /// <param name="userCreateDto">The DTO containing the user's information.</param>
        /// <returns>UserDto</returns>
        /// <exception cref="Exception">Throws an exception if there is an error while creating a User.</exception>
        public async Task<UserDto> CreateNewUserWithMainHouseAsync(UserCreateDto userCreateDto)
        {
            try
            {
                var user = await CreateUserAsync(new User(userCreateDto));

                var house = await CreateTheMainHouseAsync(user.Id);

                var location = await CreateLocation(user.Id, house.Id);

                var defaultlocation = await CreateTheDefaultLocation(user.Id, location.Id);

                return new UserDto(user, new DefaultLocationDto(defaultlocation));
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the user. {ex.Message}", ex);
            }
        }

        private async Task<House> CreateTheMainHouseAsync(int userId)
        {
            try
            {
                var house = new House
                {
                    UserId = userId,
                    Name = "Main House",
                    Indice = 1,
                    CreatedAt = DateTime.UtcNow
                };
                await context.Houses.AddAsync(house);
                await context.SaveChangesAsync();

                return house;
            }
            catch (Exception ex)
            {
                throw new Exception("CreateTheMainHouseAsync exception", ex);
            }
        }

        private async Task<Location> CreateLocation(int userId, int houseId)
        {
            var location = new Location
            {
                CreatedAt = DateTime.UtcNow,
                UserId = userId,
                HouseId = houseId
            };
            await context.Locations.AddAsync(location);
            await context.SaveChangesAsync();

            return location;
        }

        private async Task<DefaultLocation> CreateTheDefaultLocation(int userId, int locationId)
        {
            var defaultLocation = new DefaultLocation
            {
                UserId = userId,
                LocationId = locationId,
            };
            await context.DefaultLocations.AddAsync(defaultLocation);
            await context.SaveChangesAsync();

            return defaultLocation;
        }

        /// <summary>
        /// Checks if the provided user creation DTO is valid.
        /// </summary>
        /// <param name="userCreateDto">The DTO containing the user's information.</param>
        /// <returns>A boolean indicating whether the DTO is valid or not.</returns>
        /// <exception cref="Exception">Throws an exception if the email is invalid, if the email is already used, if the password length is too short, or if the password complexity requirements are not met.</exception>
        public async Task<bool> CheckUserCreateDtoAsync(UserCreateDto userCreateDto)
        {
            if (!UtilsEmail.IsValidateEmailAddressAttribute(userCreateDto.Email))
            {
                throw new Exception($"Invalid email address format : {userCreateDto.Email}");
            }
            if (await UtilsEmail.IsEmailExistInContextAsync(userCreateDto.Email, context))
            {
                throw new Exception(string.Format($"Email is already used : {userCreateDto.Email}"));
            }
            if (UtilsPassword.CheckPasswordLength(userCreateDto.Password))
            {
                throw new Exception($"The password must have at least {Utils.UtilsPassword.PASSWORD_MIN_LENGTH} characters.");
            }
            if (!UtilsPassword.CheckPasswordComplexity(userCreateDto.Password))
            {
                throw new Exception("The password must contain at least one upper case letter, one lower case letter, one number and one special character.");
            }
            return true;
        }
        #endregion

        #region UPDATE USER

        public async Task<UserDto> UpdateUserByUserUpdateDtoAsync(UserUpdateDto userUpdateDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => userUpdateDto.CurrentEmail == u.Email);
            if (user != null)
            {
                if (userUpdateDto.NewFullName == null && userUpdateDto.NewEmail == null && userUpdateDto.NewPassword == null)
                    throw new Exception("No changes needed.");

                if (userUpdateDto.NewFullName != null)
                    user.FullName = userUpdateDto.NewFullName;

                if (userUpdateDto.NewEmail != null)
                    user.Email = userUpdateDto.NewEmail;

                if (userUpdateDto.NewPassword != null)
                    user.PasswordHash = UtilsPassword.GenerateHashedPassword(userUpdateDto.NewPassword);

                user.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();

                var defaultLocationDto = await context.DefaultLocations.Where(d => d.UserId == user.Id).Select(d => new DefaultLocationDto(d)).FirstAsync();

                return new UserDto(user, defaultLocationDto);
            }
            throw new Exception("The user cannot be found.");
        }

        /// <summary>
        /// Updates the role of a user with the specified user ID.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="userRole">The new role for the user.</param>
        /// <returns>A UserSummaryDto object representing the updated user.</returns>
        /// <exception cref="Exception">Thrown if the user cannot be found.</exception>
        public async Task<UserSummaryDto> UpdateUserRoleAsync(int userId, UserRole userRole)
        {
            User? user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                user.Role = userRole;
                await context.SaveChangesAsync();
                return new UserSummaryDto(user);
            }
            throw new Exception("The user cannot be found.");
        }

        public async Task<UserSummaryDto> UpdateAuthorSignatureAsync(int userId, string authorSignature)
        {
            User? user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                user.AuthorSignature = authorSignature;
                await context.SaveChangesAsync();
                return new UserSummaryDto(user);
            }
            throw new Exception("The user cannot be found.");
        }

        #endregion

        #region DELETE USER

        /// <summary>
        /// Deletes the specified user from the database.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>A UserSummaryDto object representing the deleted user.</returns>
        /// <exception cref="Exception">Thrown if the specified user cannot be found.</exception>
        public async Task<UserSummaryDto> DeleteUserAsync(int userId)
        {
            User? user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return new UserSummaryDto(user);
            }
            throw new Exception("The user cannot be found.");
        }

        #endregion

        #region UTILS USER

        /// <summary>
        /// Check if user with given userId exists in the database
        /// </summary>
        /// <param name="userId">The ID of the user to check for.</param>
        /// <returns>Returns true if the user with given userId exists in the database, otherwise throws an exception.</returns>
        /// <exception cref="Exception">Throws exception if user with given userId doesn't exist in the database.</exception>
        public async Task<bool> IsUserExistByIdAsync(int userId)
        {
            if (await context.Users.AnyAsync(u => u.Id == userId))
                return true;

            throw new Exception($"User with ID {userId} does not exist in the database.");
        }

        public async Task<bool> CheckUserUpdateDtoAuthAsync(UserUpdateDto userUpdateDto, UserAuthDto userAuthDto)
        {
            if (userUpdateDto.CurrentFullName != userAuthDto.FullName)
                throw new Exception("The CurrentFullName is not correct.");

            if (userUpdateDto.CurrentEmail != userAuthDto.Email)
                throw new Exception("The CurrentEmail is not correct.");

            var passwordHash = await context.Users.Where(u => u.Email == userAuthDto.Email).Select(p => p.PasswordHash).FirstAsync();
            if (!Utils.UtilsPassword.CheckPasswordMatchesHash(userUpdateDto.CurrentPassword, passwordHash))
                throw new Exception("The CurrentPassword is not correct.");

            return true;
        }

        public async Task<bool> CheckUserUpdateDtoNewDataAsync(UserUpdateDto userUpdateDto)
        {
            if (userUpdateDto.NewEmail != null)
            {
                if (!UtilsEmail.IsValidateEmailAddressAttribute(userUpdateDto.NewEmail))
                {
                    throw new Exception($"Invalid email address format : {userUpdateDto.NewEmail}");
                }
                if (await UtilsEmail.IsEmailExistInContextAsync(userUpdateDto.NewEmail, context))
                {
                    throw new Exception(string.Format($"Email is already used : {userUpdateDto.NewEmail}"));
                }
            }
            if (userUpdateDto.NewPassword != null)
            {
                if (UtilsPassword.CheckPasswordLength(userUpdateDto.NewPassword))
                {
                    throw new Exception($"The password must have at least {Utils.UtilsPassword.PASSWORD_MIN_LENGTH} characters.");
                }
                if (!UtilsPassword.CheckPasswordComplexity(userUpdateDto.NewPassword))
                {
                    throw new Exception("The password must contain at least one upper case letter, one lower case letter, one number and one special character.");
                }
            }
            return true;
        }


        //public async Task<bool> ValidateUserUpdateDtoMatchesUserAuthDtoAsync(UserUpdateDto userUpdateDto, UserAuthDto userAuthDto)
        //{
        //    if (userUpdateDto.CurrentFullName == userAuthDto.FullName && userUpdateDto.CurrentEmail == userAuthDto.Email)
        //    {
        //        var passwordHash = await context.Users.Where(u => u.Email == userAuthDto.Email).Select(p => p.PasswordHash).FirstAsync();

        //        if (Utils.UtilsPassword.CheckPasswordMatchesHash(userUpdateDto.CurrentPassword, passwordHash))
        //            return true;
        //    }
        //    throw new Exception("Data does not correspond to the current user.");
        //}


        #endregion
    }
}
