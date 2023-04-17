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
        Task<UserSummaryDto?> CreateUserAsync(UserCreateDto userCreateDto);

        // READ
        /// <summary>
        /// Gets the claims identity for a user based on their login information.
        /// </summary>
        /// <param name="userLoginDto">The user's login information.</param>
        /// <returns>A <see cref="ClaimsIdentity"/> object.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while getting the claims identity.</exception>
        Task<ClaimsIdentity> GetClaimsIdentityAsync(UserLoginDto userLoginDto);

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
        Task<UserSummaryDto> UpdateUserAsync(UserUpdateDto userUpdateDto);

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
        /// <summary>
        /// Check if user with given userId exists in the database
        /// </summary>
        /// <param name="userId">The ID of the user to check for.</param>
        /// <returns>Returns true if the user with given userId exists in the database, otherwise throws an exception.</returns>
        /// <exception cref="Exception">Throws exception if user with given userId doesn't exist in the database.</exception>
        Task<bool> IsUserExistByIdAsync(int userId);

        /// <summary>
        /// Checks if the provided user login DTO is valid.
        /// </summary>
        /// <param name="userLoginDto">The user login DTO to check.</param>
        /// <returns>True if the user login DTO is valid, false otherwise.</returns>
        /// <exception cref="Exception">Thrown if the email address attribute is invalid, the email does not exist, the password hash search was unsuccessful, or the password is invalid.</exception>
        Task<bool> CheckUserLoginDtoAsync(UserLoginDto userLoginDto);

        /// <summary>
        /// Validates a user creation DTO by checking if the email address is valid and not already used, and if the password meets certain complexity requirements.
        /// </summary>
        /// <param name="userCreateDto">The user creation DTO to validate.</param>
        /// <returns>A boolean indicating whether the validation was successful or not.</returns>
        Task<bool> IsValidUserCreateDtoAsync(UserCreateDto userCreatedDto);

        /// <summary>
        /// Validates if the data in the UserUpdateDto matches the data in the UserAuthDto.
        /// </summary>
        /// <param name="userUpdateDto">The UserUpdateDto to be validated.</param>
        /// <param name="userAuthDto">The UserAuthDto to compare with.</param>
        /// <returns>True if the data in UserUpdateDto matches the data in UserAuthDto, false otherwise.</returns>
        /// <exception cref="Exception">Throws an exception if the data does not correspond to the current user.</exception>
        Task<bool> ValidateUserUpdateDtoMatchesUserAuthDtoAsync(UserUpdateDto userUpdateDto, UserAuthDto userAuthDto);

        /// <summary>
        /// Validates user update DTO data.
        /// </summary>
        /// <param name="userUpdateDto">The user update DTO to validate.</param>
        /// <returns>True if the DTO data is valid.</returns>
        /// <exception cref="Exception">Thrown if the DTO data is invalid.</exception>
        Task<bool> ValidateUserUpdateDtoDataAsync(UserUpdateDto userUpdateDto);

    }
}
