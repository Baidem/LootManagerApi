﻿using Microsoft.AspNetCore.Http;
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

        #region READ
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
        #endregion

    }
}

