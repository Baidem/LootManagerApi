using LootManagerApi.Dto;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Repositories;

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
        /// Create a new House
        /// </summary>
        /// <param name="houseCreateDto">House creation DTO object containing House information</param>
        /// <returns>Returns the info House DTO object.</returns>
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
                    await houseRepository.ThisIndexIsFreeAsync(houseCreateDto.Indice.Value, userAuthDto.Id);

                var houseDto = await houseRepository.CreateHouseAsync(houseCreateDto, userAuthDto.Id);

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
