﻿using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LootManagerApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        #region DECLARATIONS

        IRoomRepository roomRepository;
        IHouseRepository houseRepository;
        ILocationRepository locationRepository;

        #endregion

        #region CONSTRUCTOR

        public RoomController(IRoomRepository roomRepository, IHouseRepository houseRepository, ILocationRepository locationRepository)
        {
            this.roomRepository = roomRepository;
            this.houseRepository = houseRepository;
            this.locationRepository = locationRepository;
        }

        #endregion

        #region CREATE

        /// <summary>
        /// Create a new Room
        /// </summary>
        /// <param name="roomCreateDto">Room creation DTO object containing Room information</param>
        /// <returns>RoomDto</returns>
        /// <exception cref="Exception">Thrown when there is an error in creating the Room.</exception>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<RoomDto>> CreateRoom([FromForm] RoomCreateDto roomCreateDto)
        {
            try
            {
                // Check Log-in and load current user ID.
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                // Check current user is the owner of the House of the new furniture.
                await houseRepository
                    .CheckTheOwnerOfTheHouseAsync(userAuthDto.Id, roomCreateDto.HouseId);

                // If IndiceOrDefault not null => Check indice is free. Else If null => update the indice.
                roomCreateDto = await roomRepository
                    .CheckIndiceFreeOrUpdateDefaultIndice(roomCreateDto);

                // Create the Location of the new Furniture 
                var locationDto = await locationRepository
                    .CreateLocationByUserIdAsync(userAuthDto.Id);

                // Create the new Room
                var roomDto = await roomRepository
                    .CreateRoomByDtoAsync(roomCreateDto, locationDto);

                return Ok(roomDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region READ

        /// <summary>
        /// Get the list of rooms of the current user among all his houses.
        /// </summary>
        /// <returns>List of RoomDto</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for rooms.</exception>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<RoomDto>>> GetRoomsByUserId()
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var roomDtos = await roomRepository.GetRoomsByUserIdAsync(userAuthDto.Id);

                return Ok(roomDtos);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get the list of rooms of a house from the current user.
        /// </summary>
        /// <returns>List of RoomDto</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for rooms.</exception>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<RoomDto>>> GetRoomsByHouseId(int houseId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await houseRepository.CheckTheOwnerOfTheHouseAsync(userAuthDto.Id, houseId);

                var roomDtos = await roomRepository.GetRoomsByUserIdAsync(userAuthDto.Id);

                return Ok(roomDtos);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get user's room by Id.
        /// </summary>
        /// <returns>RoomDto</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for the room.</exception>
        [HttpGet("{roomId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<RoomDto>> GetRoom(int roomId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await roomRepository.CheckTheOwnerOfTheRoomAsync(userAuthDto.Id, roomId);

                var roomDto = await roomRepository.GetRoomAsync(roomId);

                return Ok(roomDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region UPDATE

        /// <summary>
        /// Updates the specified room.
        /// </summary>
        /// <param name="RoomUpdateDto">The DTO containing updated room data.</param>
        /// <returns>RoomDto</returns>
        /// <exception cref="Exception">Throw if there is an error when updating the room.</exception>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<RoomDto>> UpdateRoom([FromForm] RoomUpdateDto roomUpdateDto)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await roomRepository.CheckTheOwnerOfTheRoomAsync(userAuthDto.Id, roomUpdateDto.Id);

                await houseRepository.CheckTheOwnerOfTheHouseAsync(userAuthDto.Id, roomUpdateDto.HouseId);

                var roomUpdated = await roomRepository.UpdateRoomByDtoAsync(roomUpdateDto);

                return Ok(roomUpdated);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Delete an room by its Id.
        /// </summary>
        /// <param name="roomId">The Id of the room to delete.</param>
        /// <returns>RoomDto</returns>
        /// <exception cref="Exception">Throw if there is an error when deleting the room.</exception>
        [HttpDelete("{roomId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<RoomDto>> DeleteRoom(int roomId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await roomRepository.CheckTheOwnerOfTheRoomAsync(userAuthDto.Id, roomId);

                RoomDto roomDto = await roomRepository.DeleteRoomAsync(roomId);

                return Ok(roomDto);
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
