using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LootManagerApi;
using LootManagerApi.Repositories;
using LootManagerApi.Repositories.Interfaces;
using LootManagerApi.Dto;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace LootManagerApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region DECLARATIONS
        IUserRepository userRepository;
        #endregion

        #region CONSTRUCTOR
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        #endregion

        #region LOG
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Login([FromForm] UserLoginDto userLoginDto)
        {
            try
            {
                await userRepository.CheckUserLoginDtoAsync(userLoginDto);
                var identity = userRepository.GetClaimsIdentity(userLoginDto);
                return Ok($"{identity.FindFirst(ClaimTypes.Name).Value} is connected.");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok("Log out");
        }
        #endregion
    }
}

