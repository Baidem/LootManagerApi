using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Repositories;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LootManagerApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class FurnitureController : ControllerBase
    {
        #region DECLARATIONS

        IFurnitureRepository furnitureRepository;
        IRoomRepository roomRepository;
        ILocationRepository locationRepository;

        #endregion

        #region CONSTRUCTOR
        public FurnitureController(IFurnitureRepository furnitureRepository, IRoomRepository roomRepository, ILocationRepository locaqtionRepository)
        {
            this.furnitureRepository = furnitureRepository;
            this.roomRepository = roomRepository;
            this.locationRepository = locaqtionRepository;
        }
        #endregion

        #region CREATE

        /// <summary>
        /// Create a new furniture and these shelves, positions et locations
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
                furnitureCreateDto.IndiceOrDefault = await furnitureRepository.
                    CheckIndiceFreeOrUpdateDefaultIndice(furnitureCreateDto.IndiceOrDefault, furnitureCreateDto.RoomId);

                // Create the Location of the new Furniture 
                var locationDto = await locationRepository.
                    CreateLocationByUserIdAsync(userAuthDto.Id);

                // Create the new Furniture
                var furnitureDto = await furnitureRepository.
                    CreateFurnitureByDtoAsync(furnitureCreateDto, locationDto);

                // If NumberOfShelves > 0 => implement N shelves And Create a Location per shelf


                //     If NumberOfPositionsPerShelf > 0 =>  implement N positions per shelves And Create a Location per position


                // Build the DTO


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
