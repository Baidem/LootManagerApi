using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LootManagerApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        #region DECLARATIONS

        IPositionRepository positionRepository;
        IShelfRepository shelfRepository;
        ILocationRepository locationRepository;

        #endregion

        #region CONSTRUCTOR

        public PositionController(IPositionRepository positionRepository, IShelfRepository shelfRepository, ILocationRepository locaqtionRepository)
        {
            this.positionRepository = positionRepository;
            this.shelfRepository = shelfRepository;
            this.locationRepository = locaqtionRepository;
        }

        #endregion

        #region CREATE

        /// <summary>
        /// Create a new position and his locations
        /// </summary>
        /// <param name="positionCreateDto">position creation DTO object containing position information</param>
        /// <returns>PositionDto</returns>
        /// <exception cref="Exception">Thrown when there is an error in creating the position.</exception>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PositionDto>> CreatePosition([FromForm] PositionCreateDto positionCreateDto)
        {
            try
            {
                // Check Log-in and load current user ID.
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                // Check current user is the owner of the shelf of the new position.
                await shelfRepository.
                    CheckTheOwnerOfTheShelfAsync(userAuthDto.Id, positionCreateDto.ShelfId);

                // If IndiceOrDefault not null => Check indice is free. Else If null => update the indice.
                positionCreateDto = await positionRepository.
                    CheckIndiceFreeOrUpdateDefaultIndice(positionCreateDto);

                // Create the Location of the new Furniture 
                var locationDto = await locationRepository.
                    CreateLocationByUserIdAsync(userAuthDto.Id);

                // Create the new Position
                var positionDto = await positionRepository.
                    CreatePositionByDtoAsync(positionCreateDto, locationDto);

                return Ok(positionDto);
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
