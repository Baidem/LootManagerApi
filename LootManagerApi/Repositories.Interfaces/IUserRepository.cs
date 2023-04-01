using LootManagerApi.Dto;
using LootManagerApi.Entities;
using System.Security.Claims;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CheckUserLoginDtoAsync(UserLoginDto userLoginDto);
        Task<ClaimsIdentity> GetClaimsIdentityAsync(UserLoginDto userLoginDto);
        Task<List<UserSummaryDto>> GetAllUsersAsync();
        Task<UserSummaryDto?> CreateUserAsync(UserCreateDto userCreateDto);
        Task<bool> IsValidUserCreateDtoAsync(UserCreateDto userCreatedDto);
        Task<UserSummaryDto> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<bool> ValidateUserUpdateDtoMatchesUserAuthDto(UserUpdateDto userUpdateDto, UserAuthDto userAuthDto);
        Task<bool> ValidateUserUpdateDtoDataAsync(UserUpdateDto userUpdateDto);
        Task<bool> IsUserExistByIdAsync(int userId);
        Task<UserSummaryDto> DeleteElementAsync(int userId);
        Task<UserSummaryDto> UpdateUserRoleAsync(int userId, UserRole userRole);

    }
}
