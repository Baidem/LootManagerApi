using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Dto;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LootManagerApi.Repositories;

namespace LootManagerApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        #region DECLARATIONS

        IShelfRepository shelfRepository;
        IFurnitureRepository furnitureRepository;
        IPositionRepository positionRepository;
        ILocationRepository locationRepository;

        #endregion

        #region CONSTRUCTOR
        public ShelfController(IShelfRepository shelfRepository, IFurnitureRepository furnitureRepository, IPositionRepository positionRepository, ILocationRepository locaqtionRepository)
        {
            this.shelfRepository = shelfRepository;
            this.furnitureRepository = furnitureRepository;
            this.positionRepository = positionRepository;
            this.locationRepository = locaqtionRepository;

        }

        #endregion

        #region CREATE

        /// <summary>
        /// Create a new shelf and these positions and locations
        /// </summary>
        /// <param name="shelfCreateDto">shelf creation DTO object containing shelf information</param>
        /// <returns>ShelfDto</returns>
        /// <exception cref="Exception">Thrown when there is an error in creating the shelf.</exception>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ShelfDto>> CreateShelf([FromForm] ShelfCreateDto shelfCreateDto)
        {
            try
            {
                // Check Log-in and load current user ID.
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                // Check current user is the owner of the furniture of the new shelf.
                await furnitureRepository.
                    CheckTheOwnerOfTheFurnitureAsync(userAuthDto.Id, shelfCreateDto.FurnitureId);

                // If IndiceOrDefault not null => Check indice is free. Else If null => update the indice.
                shelfCreateDto = await shelfRepository.
                    CheckIndiceFreeOrUpdateDefaultIndice(shelfCreateDto);

                // Create the Location of the new Shelf 
                var locationDto = await locationRepository.
                    CreateLocationByUserIdAsync(userAuthDto.Id);

                // Create the new Shelf
                var shelfDto = await shelfRepository.
                    CreateShelfByDtoAsync(shelfCreateDto, locationDto);

                // If NumberOfPositionsPerShelf > 0 =>  implement N positions And Create a Location per position
                shelfDto = await positionRepository.
                    GeneratePositionsAsync(shelfDto);

                // Build the DTO


                return Ok(shelfDto);
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
