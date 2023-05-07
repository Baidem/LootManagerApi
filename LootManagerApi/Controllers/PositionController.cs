using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Repositories;
using LootManagerApi.Repositories.Interfaces;
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
                await shelfRepository
                    .CheckTheOwnerOfTheShelfAsync(userAuthDto.Id, positionCreateDto.ShelfId);

                // If IndiceOrDefault not null => Check indice is free. Else If null => update the indice.
                positionCreateDto = await positionRepository
                    .CheckIndiceFreeOrUpdateDefaultIndice(positionCreateDto);

                // Create the Location of the new Position 
                var locationDto = await locationRepository
                    .CreateLocationByUserIdAsync(userAuthDto.Id);

                // Create the new Position
                var positionDto = await positionRepository
                    .CreatePositionByDtoAsync(positionCreateDto, locationDto);

                return Ok(positionDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        #endregion

        #region READ

        /// <summary>
        /// Get user's position by Id.
        /// </summary>
        /// <param name="positionId">The position ID</param>
        /// <returns>PositionDto</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for the position.</exception>
        [HttpGet("{positionId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PositionDto>> GetPositionById(int positionId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await positionRepository.CheckTheOwnerOfThePositionAsync(userAuthDto.Id, positionId);

                var positionDto = await positionRepository.GetPositionDtoByIdAsync(positionId);

                return Ok(positionDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get the list of Positions of the current user.
        /// </summary>
        /// <returns>List of PositionDto</returns>
        /// <param name="numberOfElements">The maximum number of elements in the list</param>
        /// <exception cref="Exception">Throw if there is an error when searching for Position.</exception>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<PositionDto>>> GetPositionsOfCurrentUser(int numberOfElements = 100)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var positionDtoList = await positionRepository.GetListOfPositionDtoByUserIdAsync(userAuthDto.Id, numberOfElements);

                return Ok(positionDtoList);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get the list of Positions by Shelf ID.
        /// </summary>
        /// <returns>List of PositionDto</returns>
        /// <param name="shelfId">The shelf ID</param>
        /// <param name="numberOfElements">The maximum number of elements in the list</param>
        /// <exception cref="Exception">Throw if there is an error when searching for Position.</exception>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<PositionDto>>> GetPositionsByShelfId(int shelfId,int numberOfElements = 100)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var positionDtoList = await positionRepository.GetListOfPositionDtoByShelfIdAsync(shelfId, numberOfElements);

                return Ok(positionDtoList);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get the list of Positions by name search.
        /// </summary>
        /// <returns>List of PositionDto</returns>
        /// <param name="nameSearch"></param>
        /// <param name="numberOfElements">The maximum number of elements in the list</param>
        /// <exception cref="Exception">Throw if there is an error when searching for Position.</exception>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<PositionDto>>> GetPositionsByNameSearch(string nameSearch, int numberOfElements = 100)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var positionDtoList = await positionRepository.GetListOfPositionDtoByNameSearchAsync(userAuthDto.Id, nameSearch, numberOfElements);

                return Ok(positionDtoList);
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
