﻿using LootManagerApi.Dto;
using LootManagerApi.Entities;
using LootManagerApi.Repositories;
using LootManagerApi.Repositories.Interfaces;
using LootManagerApi.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LootManagerApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class InfoSheetController : ControllerBase
    {
        #region DECLARATIONS
        IInfoSheetRepository infoSheetRepository;

        #endregion

        #region CONSTRUCTOR
        public InfoSheetController(IInfoSheetRepository infoSheetRepository)
        {
            this.infoSheetRepository = infoSheetRepository;
        }
        #endregion

        #region LOG
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

        #region CREATE
        /// <summary>
        /// Creates a new info sheet.
        /// </summary>
        /// <param name="infoSheetCreateDto">Info sheet creation DTO object containing info sheet information.</param>
        /// <returns>Returns the info sheet summary DTO object.</returns>
        /// <exception cref="Exception">Thrown when there is an error in creating the info sheet.</exception>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<InfoSheetSummaryDto>> CreateInfoSheet([FromForm] InfoSheetCreateDto infoSheetCreateDto)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                UtilsRole.CheckOnlyContributor(userAuthDto);

                var infoSheetSummaryDto = await infoSheetRepository.CreateInfoSheetAsync(infoSheetCreateDto, userAuthDto.Id.Value);

                return Ok(infoSheetSummaryDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region READ

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<InfosheetIdAndDesignation>>> GetAllMyInfoSheets()
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                UtilsRole.CheckOnlyContributor(userAuthDto);

                var elements = await infoSheetRepository.GetAllInfoSheetByUserIdAsync(userAuthDto.Id.Value);

                return Ok(elements);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<InfoSheet>> GetInfoSheetById(int infoSheetId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await infoSheetRepository.IsInfoSheetExistAsync(infoSheetId);

                var element = await infoSheetRepository.GetInfoSheetByIdAsync(infoSheetId);

                return Ok(element);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        #endregion

        #region UPDATE

        #endregion

        #region DELETE

        #endregion



    }
}
