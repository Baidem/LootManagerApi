using LootManagerApi.Dto;
using LootManagerApi.Entities;
using System.Security.Claims;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        // CREATE
        /// <summary>
        /// Creates a new user asynchronously and returns a summary of the created user.
        /// </summary>
        /// <param name="userCreateDto">The DTO containing the user's information.</param>
        /// <returns>A UserSummaryDto representing the created user.</returns>
        /// <exception cref="Exception">Throws an exception if there is an error while saving the changes to the database.</exception>
        Task<UserDto> CreateNewUserWithMainHouseAsync(UserCreateDto userCreateDto);
        Task<User> CreateUserAsync(User user);

        // READ
        /// <summary>
        /// Gets the claims identity for a user based on their login information.
        /// </summary>
        /// <param name="userLoginDto">The user's login information.</param>
        /// <returns>A <see cref="ClaimsIdentity"/> object.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while getting the claims identity.</exception>
        Task<ClaimsIdentity> GetClaimsIdentityAsync(UserLoginDto userLoginDto);
        Task<UserDto> GetUserDto(int userId);

        /// <summary>
        /// Retrieves a list of all user summary data asynchronously from the database.
        /// </summary>
        /// <returns>A list of UserSummaryDto objects containing summary data for all users.</returns>
        Task<List<UserSummaryDto>> GetAllUsersAsync();

        // UPDATE
        /// <summary>
        /// Updates an existing user's information in the database.
        /// </summary>
        /// <param name="userUpdateDto">The user update DTO containing the updated user information.</param>
        /// <returns>A UserSummaryDto object containing the updated user information.</returns>
        /// <exception cref="Exception">Thrown if the user cannot be found or if no changes were made.</exception>
        Task<UserDto> UpdateUserByUserUpdateDtoAsync(UserUpdateDto userUpdateDto);

        /// <summary>
        /// Updates the role of a user with the specified user ID.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="userRole">The new role for the user.</param>
        /// <returns>A UserSummaryDto object representing the updated user.</returns>
        /// <exception cref="Exception">Thrown if the user cannot be found.</exception>
        Task<UserSummaryDto> UpdateUserRoleAsync(int userId, UserRole userRole);
        Task<UserSummaryDto> UpdateAuthorSignatureAsync(int userId, string authorSignature);

        // DELETE
        /// <summary>
        /// Deletes the specified user from the database.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>A UserSummaryDto object representing the deleted user.</returns>
        /// <exception cref="Exception">Thrown if the specified user cannot be found.</exception>
        Task<UserSummaryDto> DeleteUserAsync(int userId);

        // UTILS
        Task<bool> IsUserExistByIdAsync(int userId);
        Task<bool> CheckUserLoginDtoAsync(UserLoginDto userLoginDto);
        Task<bool> CheckUserCreateDtoAsync(UserCreateDto userCreatedDto);
        //Task<bool> ValidateUserUpdateDtoMatchesUserAuthDtoAsync(UserUpdateDto userUpdateDto, UserAuthDto userAuthDto);
        Task<bool> CheckUserUpdateDtoNewDataAsync(UserUpdateDto userUpdateDto);

        Task<bool> CheckUserUpdateDtoAuthAsync(UserUpdateDto userUpdateDto, UserAuthDto userAuthDto);

    }
}
