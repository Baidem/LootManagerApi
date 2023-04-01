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
using Microsoft.Extensions.Logging;
using LootManagerApi.Utils;
using LootManagerApi.Entities;

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

        private UserAuthDto loadUserAuthentifiedDto()
        {
            var identity = User?.Identity as ClaimsIdentity;
            if (identity?.FindFirst(ClaimTypes.NameIdentifier) == null)
            {
                throw new Exception("You must log in.");
            }
            return new UserAuthDto(identity);
        }
        #endregion

        #region CREATE USER    
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserSummaryDto>> CreateUser([FromForm] UserCreateDto userCreateDto)
        {
            try
            {
                await userRepository.IsValidUserCreateDtoAsync(userCreateDto);
                var userSummaryDto = await userRepository.CreateUserAsync(userCreateDto);
                return Ok(userSummaryDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region READ
        [HttpGet]
        public async Task<ActionResult<List<UserSummaryDto>>> GetAllUsersAsync()
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();
                UtilsRole.CheckOnlyAdmin(userAuthDto);
                var userSummaryDtoList = await userRepository.GetAllUsersAsync();
                return Ok(userSummaryDtoList);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region UPDATE USER
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> UpdateUser([FromForm] UserUpdateDto userUpdateDto)
        {
            try
            {
                var userAuthDto = loadUserAuthentifiedDto();
                await userRepository.ValidateUserUpdateDtoMatchesUserAuthDto(userUpdateDto, userAuthDto);
                await userRepository.ValidateUserUpdateDtoDataAsync(userUpdateDto);
                var userSummaryDto = await userRepository.UpdateUserAsync(userUpdateDto);
                string password = (userUpdateDto.NewPassword == null) ? userUpdateDto.CurrentPassword : userUpdateDto.NewPassword;
                await updateUserIdentity(userSummaryDto.Email, password);

                return Ok($"The user is update : FullName = {userSummaryDto.FullName}, Email = {userSummaryDto.Email}, Password = {dotsLine(userUpdateDto)}");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        private async Task updateUserIdentity(string email, string password)
        {
            var userLoginDto = new UserLoginDto { Email = email, Password = password };
            var identity = await userRepository.GetClaimsIdentityAsync(userLoginDto);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }
        private string dotsLine(UserUpdateDto userUpdateDto)
        {
            int dotsLength;
            if (userUpdateDto.NewPassword == null)
                dotsLength = userUpdateDto.CurrentPassword.Length;
            else
                dotsLength = userUpdateDto.NewPassword.Length;
            return new string('●', dotsLength);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> UpdateUserRole(int userId, UserRole userRole)
        {
            try
            {
                var userAuthDto = loadUserAuthentifiedDto();
                UtilsRole.CheckOnlyAdmin(userAuthDto);
                await userRepository.IsUserExistByIdAsync(userId);
                UserSummaryDto userSummaryDto = await userRepository.UpdateUserRoleAsync(userId, userRole);

                return Ok($"The role of {userSummaryDto.FullName} {userSummaryDto.Email} is : {userRole}");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region DELETE USER

        [HttpDelete("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<string>> DeleteUserByIdAsync(int userId)
        {
            try
            {
                // check log
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();
                // check role
                UtilsRole.CheckOnlyAdmin(userAuthDto);
                // check user to delete
                await userRepository.IsUserExistByIdAsync(userId);
                // Delete the user
                UserSummaryDto userSummaryDto = await userRepository.DeleteElementAsync(userId);

                return Ok($"{userSummaryDto.FullName} was deleted.");
            }
            catch (Exception)
            {
                // TODO return
                throw;
            }

        }


        #endregion



    }
}

