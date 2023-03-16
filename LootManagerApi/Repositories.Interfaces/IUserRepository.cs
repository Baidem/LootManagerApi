using LootManagerApi.Dto;
using System.Security.Claims;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CheckUserLoginDtoAsync(UserLoginDto userLoginDto);
        ClaimsIdentity? GetClaimsIdentity(UserLoginDto userLoginDto);
    }
}
