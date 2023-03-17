using LootManagerApi.Dto;
using System.Security.Claims;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CheckUserLoginDtoAsync(UserLoginDto userLoginDto);
        Task<ClaimsIdentity?> GetClaimsIdentityAsync(UserLoginDto userLoginDto);
        Task<List<UserSummaryDto>> GetAllUsersAsync();
    }
}
