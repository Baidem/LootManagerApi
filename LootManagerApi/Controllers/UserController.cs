using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LootManagerApi;
using LootManagerApi.Repositories;
using LootManagerApi.Repositories.Interfaces;
using LootManagerApi.Dto;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

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
                var identity = await userRepository.GetClaimsIdentityAsync(userLoginDto);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
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

        private UserAuthentifiedDto loadUserAuthentifiedDto()
        {
            var identity = User?.Identity as ClaimsIdentity;
            if (identity?.FindFirst(ClaimTypes.NameIdentifier) == null)
            {
                throw new Exception("You must log in.");
            }
            return new UserAuthentifiedDto(identity);
        }
        #endregion

        #region GET
        [HttpGet]
        public async Task<ActionResult<List<UserSummaryDto>>> GetAllUsersAsync()
        {
            try
            {
                loadUserAuthentifiedDto();
                // To do Vérifier rôle de l'utilisateur
                var userSummaryDtoList = await userRepository.GetAllUsersAsync();
                return Ok(userSummaryDtoList);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region POST

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserSummaryDto>> CreateUser([FromForm] UserCreateDto userCreateDto)
        {
            var userSummaryDto = await userRepository.CreateUserAsync(userCreateDto);
            return Ok(userSummaryDto);
        }

        #endregion
    }
}

