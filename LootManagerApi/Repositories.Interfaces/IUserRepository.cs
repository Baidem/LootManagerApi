using LootManagerApi.Dto;
using System.Security.Claims;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        bool CheckUserLoginDto();
        ClaimsIdentity? GetClaimsIdentity(UserLoginDto userLoginDto);
    }
}
