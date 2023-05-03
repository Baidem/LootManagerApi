using LootManagerApi.Dto;
using LootManagerApi.Entities;
using System.Security.Claims;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        // CREATE
        Task<UserDto> CreateNewUserWithMainHouseAsync(UserCreateDto userCreateDto);
        Task<User> CreateUserAsync(User user);

        // READ
        Task<ClaimsIdentity> GetClaimsIdentityAsync(UserLoginDto userLoginDto);
        Task<UserDto> GetUserDto(int userId);

        Task<List<UserSummaryDto>> GetAllUsersAsync();

        // UPDATE
        Task<UserDto> UpdateUserByUserUpdateDtoAsync(UserUpdateDto userUpdateDto);

        Task<UserSummaryDto> UpdateUserRoleAsync(int userId, UserRole userRole);
        Task<UserSummaryDto> UpdateAuthorSignatureAsync(int userId, string authorSignature);

        // DELETE
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
