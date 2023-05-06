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
    public class FurnitureController : ControllerBase
    {
        #region DECLARATIONS

        IRoomRepository roomRepository;
        IFurnitureRepository furnitureRepository;
        IShelfRepository shelfRepository;
        ILocationRepository locationRepository;

        #endregion

        #region CONSTRUCTOR

        public FurnitureController(IRoomRepository roomRepository, IFurnitureRepository furnitureRepository, IShelfRepository shelfRepository, ILocationRepository locationRepository)
        {
            this.roomRepository = roomRepository;
            this.furnitureRepository = furnitureRepository;
            this.shelfRepository = shelfRepository;
            this.locationRepository = locationRepository;
        }

        #endregion

        #region READ

        /// <summary>
        /// Get user's Furniture by Id.
        /// </summary>
        /// <param name="furnitureId">The furniture ID</param>
        /// <returns>FurnitureDto</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for the furniture.</exception>
        [HttpGet("{furnitureId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<FurnitureDto>> GetFurnitureById(int furnitureId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await furnitureRepository.CheckTheOwnerOfTheFurnitureAsync(userAuthDto.Id, furnitureId);

                var furnitureDto = await furnitureRepository.GetFurnitureDtoByIdAsync(furnitureId);

                return Ok(furnitureDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get the list of Furnitures of the current user.
        /// </summary>
        /// <returns>List of FurnitureDto</returns>
        /// <param name="numberOfElements">The maximum number of elements in the list</param>
        /// <exception cref="Exception">Throw if there is an error when searching for Furniture.</exception>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<FurnitureDto>>> GetFurnituresOfCurrentUser(int numberOfElements = 100)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var furnitureDtoList = await furnitureRepository.GetListOfFurnitureDtoByUserIdAsync(userAuthDto.Id, numberOfElements);

                return Ok(furnitureDtoList);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get the list of Furnitures by Room ID.
        /// </summary>
        /// <returns>List of FurnitureDto</returns>
        /// <param name="roomId">The room ID</param>
        /// <param name="numberOfElements">The maximum number of elements in the list</param>
        /// <exception cref="Exception">Throw if there is an error when searching for Furniture.</exception>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<FurnitureDto>>> GetFurnituresByRoomId(int roomId, int numberOfElements = 100)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var furnitureDtoList = await furnitureRepository.GetListOfFurnitureDtoByRoomIdAsync(roomId, numberOfElements);

                return Ok(furnitureDtoList);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region CREATE

        /// <summary>
        /// Create a new furniture and these shelves, positions and locations
        /// </summary>
        /// <param name="furnitureCreateDto">furniture creation DTO object containing furniture information</param>
        /// <returns>FurnitureDto</returns>
        /// <exception cref="Exception">Thrown when there is an error in creating the furniture.</exception>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<FurnitureDto>> CreateFurniture([FromForm] FurnitureCreateDto furnitureCreateDto)
        {
            try
            {
                // Check Log-in and load current user ID.
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                // Check current user is the owner of the room of the new furniture.
                await roomRepository.
                    CheckTheOwnerOfTheRoomAsync(userAuthDto.Id, furnitureCreateDto.RoomId);

                // If IndiceOrDefault not null => Check indice is free. Else If null => update the indice.
                furnitureCreateDto.IndiceOrDefault = await furnitureRepository
                    .CheckIndiceFreeOrUpdateDefaultIndice(furnitureCreateDto.IndiceOrDefault, furnitureCreateDto.RoomId);

                // Create the Location of the new Furniture 
                var locationDto = await locationRepository
                    .CreateLocationByUserIdAsync(userAuthDto.Id);

                // Create the new Furniture
                var furnitureDto = await furnitureRepository
                    .CreateFurnitureByDtoAsync(furnitureCreateDto, locationDto);

                // If NumberOfShelves > 0 => implement N shelves And Create a Location per shelf
                //     If NumberOfPositionsPerShelf > 0 =>  implement N positions per shelves And Create a Location per position
                furnitureDto = await shelfRepository
                    .GenerateShelvesAsync(furnitureDto, furnitureCreateDto.NumberOfShelves, furnitureCreateDto.NumberOfPositionsPerShelf);

                return Ok(furnitureDto);
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
