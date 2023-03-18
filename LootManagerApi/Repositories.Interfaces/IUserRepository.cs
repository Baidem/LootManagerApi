using LootManagerApi.Dto;
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
        Task<bool> CheckUserUpdateDtoIsUserAuthentifiedAsync(UserUpdateDto userUpdateDto, UserAuthentifiedDto userAuthentifiedDto);



    }
}
