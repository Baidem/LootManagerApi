using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities;
using LootManagerApi.Repositories.Interfaces;
using LootManagerApi.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LootManagerApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region DECLARATIONS

        IUserRepository userRepository;
        IHouseRepository houseRepository;

        #endregion

        #region CONSTRUCTOR

        public UserController(IUserRepository userRepository, IHouseRepository houseRepository)
        {
            this.userRepository = userRepository;
            this.houseRepository = houseRepository;
        }

        #endregion

        #region LOG

        /// <summary>
        /// Logs a user into the system using their login credentials.
        /// </summary>
        /// <param name="userLoginDto">The user's login credentials.</param>
        /// <returns>An HTTP 200 (OK) response with a message indicating that the user is connected.</returns>
        /// <exception cref="Exception">Thrown if an error occurs during the login process.</exception>
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

        /// <summary>
        /// This function logs out the currently signed in user and returns an Ok result indicating success.
        /// </summary>
        /// <returns>An IActionResult indicating the result of the logout process, which is always Ok if the logout was successful.</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok("Log out");
        }

        /// <summary>
        /// Loads the UserAuthDto for an authenticated user.
        /// </summary>
        /// <returns>The UserAuthDto for the authenticated user.</returns>
        /// <exception cref="Exception">Thrown if the user is not authenticated.</exception>
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

        /// <summary>
        /// Create a new user with the main location.
        /// </summary>
        /// <param name="userCreateDto">User creation DTO object containing user information.</param>
        /// <returns>UserDto</returns>
        /// <exception cref="Exception">Thrown when there is an error in creating the user.</exception>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserDto>> CreateNewUserWithTheMainHouse([FromForm] UserCreateDto userCreateDto)
        {
            try
            {
                await userRepository.CheckUserCreateDtoAsync(userCreateDto);

                var userDto = await userRepository.CreateNewUserWithMainHouseAsync(userCreateDto);

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region READ

        /// <summary>
        /// Retrieves a list of all user summary DTOs from the repository and returns them in an ActionResult.
        /// </summary>
        /// <returns>UserSummaryDto</returns>
        /// <exception cref="Exception">Thrown when there is an error retrieving the list of users or when the current user is not authorized to retrieve the list.</exception> 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<UserSummaryDto>>> GetAllUsers()
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

        /// <summary>
        /// -Administrator fonction-.
        /// Get the user's dto by the user's ID
        /// </summary>
        /// <returns>UserDto</returns>
        /// <exception cref="Exception"></exception> 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserDto>> GetUserDtoById(int userId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                UtilsRole.CheckOnlyAdmin(userAuthDto);

                var userDto = await userRepository.GetUserDto(userId);

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get the user's dto of the current user.
        /// </summary>
        /// <returns>UserDto</returns>
        /// <exception cref="Exception"></exception> 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserDto>> GetMyUserDto()
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var userDto = await userRepository.GetUserDto(userAuthDto.Id);

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region UPDATE USER

        /// <summary>
        /// Updates the user with the provided UserUpdateDto object.
        /// </summary>
        /// <param name="userUpdateDto">The UserUpdateDto object containing the new user information.</param>
        /// <returns>UserDto</returns>
        /// <exception cref="Exception">Thrown if the user is not authorized or if the UserUpdateDto is invalid.</exception>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserDto>> UpdateUser([FromForm] UserUpdateDto userUpdateDto)
        {
            try
            {
                var userAuthDto = loadUserAuthentifiedDto();

                await userRepository.CheckUserUpdateDtoAuthAsync(userUpdateDto, userAuthDto);

                await userRepository.CheckUserUpdateDtoNewDataAsync(userUpdateDto);

                var userDto = await userRepository.UpdateUserByUserUpdateDtoAsync(userUpdateDto);

                string password = (userUpdateDto.NewPassword == null) ? userUpdateDto.CurrentPassword : userUpdateDto.NewPassword;
                await updateUserIdentityAsync(userDto.Email, password);

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates the user identity with the provided email and password.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="Exception">Thrown if the user cannot be authenticated.</exception>
        private async Task updateUserIdentityAsync(string email, string password)
        {
            var identity = await userRepository.GetClaimsIdentityAsync(new UserLoginDto { Email = email, Password = password });
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }

        /// <summary>
        /// This method returns a string of dots ('●') that is the same length as the password that needs to be obfuscated.
        /// </summary>
        /// <param name="userUpdateDto">The UserUpdateDto object containing the passwords to be obfuscated.</param>
        /// <returns>A string of dots ('●') of the same length as the password to be obfuscated.</returns>
        private string dotsLine(UserUpdateDto userUpdateDto)
        {
            int dotsLength;
            if (userUpdateDto.NewPassword == null)
                dotsLength = userUpdateDto.CurrentPassword.Length;
            else
                dotsLength = userUpdateDto.NewPassword.Length;
            return new string('●', dotsLength);
        }

        /// <summary>
        /// Updates the role of a user identified by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="userRole">The new role for the user.</param>
        /// <returns>An ActionResult indicating success or failure.</returns>
        [HttpPut]
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

        /// <summary>
        /// Updates the author signature of a user.
        /// </summary>
        /// <param name="authorSignature">The new author signature to be set.</param>
        /// <returns>An ActionResult object indicating the result of the operation.</returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> UpdateAuthorSignature(string authorSignature)
        {
            try
            {
                var userAuthDto = loadUserAuthentifiedDto();
                UtilsRole.CheckOnlyContributor(userAuthDto);
                await userRepository.IsUserExistByIdAsync(userAuthDto.Id);
                UserSummaryDto userSummaryDto = await userRepository.UpdateAuthorSignatureAsync(userAuthDto.Id, authorSignature);

                return Ok($"The author signature of {userSummaryDto.FullName} {userSummaryDto.Email} is : {authorSignature}");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        #endregion

        #region DELETE USER

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>A string indicating the success or failure of the operation.</returns>
        /// <exception cref="Exception">Thrown if the authenticated user is not an admin, if the user ID is invalid, or if there is an error deleting the user.</exception>
        [HttpDelete("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<string>> DeleteUserByIdAsync(int userId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                UtilsRole.CheckOnlyAdmin(userAuthDto);

                await userRepository.IsUserExistByIdAsync(userId);

                UserSummaryDto userSummaryDto = await userRepository.DeleteUserAsync(userId);

                return Ok($"{userSummaryDto.FullName} was deleted.");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

    }
}

