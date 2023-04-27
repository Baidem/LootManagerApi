using LootManagerApi.Dto;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Repositories;
using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        #region DECLARATIONS

        IHouseRepository houseRepository;

        #endregion

        #region CONSTRUCTOR

        public HouseController(IHouseRepository houseRepository)
        {
            this.houseRepository = houseRepository;
        }

        #endregion

        #region CREATE

        /// <summary>
        /// Create a new House. House ID is required. Only non-null data will be modified.
        /// </summary>
        /// <param name="houseCreateDto">House creation DTO object containing House information</param>
        /// <returns>HouseDto</returns>
        /// <exception cref="Exception">Thrown when there is an error in creating the House.</exception>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<HouseDto>>> CreateHouse([FromForm] HouseCreateDto houseCreateDto)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                if (houseCreateDto.Indice == null)
                    houseCreateDto.Indice = await houseRepository.AutoIndice(userAuthDto.Id);
                else
                    await houseRepository.CheckIndiceIsFreeAsync(houseCreateDto.Indice.Value, userAuthDto.Id);

                var houseDto = await houseRepository.CreateHouseByDtoAsync(houseCreateDto, userAuthDto.Id);

                return Ok(houseDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region READ

        /// <summary>
        /// Get the list of houses of the current user.
        /// </summary>
        /// <returns>List of HouseDto</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for houses.</exception>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<HouseDto>>> GetHouses()
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var houseDtos = await houseRepository.GetListOfHouseDtoByUserIdAsync(userAuthDto.Id);

                return Ok(houseDtos);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get user's house by Id.
        /// </summary>
        /// <returns>HouseDto</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for the house.</exception>
        [HttpGet("{houseId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<HouseDto>> GetHouse(int houseId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await houseRepository.CheckTheOwnerOfTheHouseAsync(userAuthDto.Id, houseId);

                var houseDto = await houseRepository.GetHouseDtoByHouseIdAsync(houseId);

                return Ok(houseDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region UPDATE

        /// <summary>
        /// Updates the specified house.
        /// </summary>
        /// <param name="HouseUpdateDto">The DTO containing updated house data.</param>
        /// <returns>HouseDto</returns>
        /// <exception cref="Exception">Throw if there is an error when updating the house.</exception>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<HouseDto>> UpdateHouse([FromForm] HouseUpdateDto houseUpdateDto)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await houseRepository.CheckTheOwnerOfTheHouseAsync(userAuthDto.Id, houseUpdateDto.Id);

                if (houseUpdateDto.Indice != null)
                    await houseRepository.CheckIndiceIsFreeAsync(houseUpdateDto.Indice.Value, userAuthDto.Id);

                var houseUpdated = await houseRepository.UpdateHouseByDtoAsync(houseUpdateDto);

                return Ok(houseUpdated);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Delete an house by its Id.
        /// </summary>
        /// <param name="houseId">The Id of the house to delete.</param>
        /// <returns>HouseDto</returns>
        /// <exception cref="Exception">Throw if there is an error when deleting the house.</exception>
        [HttpDelete("{houseId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<HouseDto>> DeleteHouse(int houseId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await houseRepository.CheckTheOwnerOfTheHouseAsync(userAuthDto.Id, houseId);

                HouseDto houseDto = await houseRepository.DeleteHouseAsync(houseId);

                return Ok(houseDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
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
    }
}
