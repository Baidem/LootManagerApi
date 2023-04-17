using LootManagerApi.Dto;
using LootManagerApi.Repositories;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LootManagerApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        #region DECLARATIONS
        ILocationRepository locationRepository;
        #endregion

        #region CONSTRUCTOR
        public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        #endregion

        #region CREATE

        /// <summary>
        /// Create a new location
        /// </summary>
        /// <param name="locationCreateDto">Location creation DTO object containing location information</param>
        /// <returns>Returns the location DTO object.</returns>
        /// <exception cref="Exception">Thrown when there is an error in creating the location.</exception>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<LocationDto>>> CreateLocation([FromForm] LocationCreateDto locationCreateDto)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var locationDto = await locationRepository.CreateLocationAsync(locationCreateDto, userAuthDto.Id);

                return Ok(locationDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region READ

        /// <summary>
        /// Get the current user's list of locations.
        /// </summary>
        /// <returns>Returns list of location DTO object.</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for locations.</exception>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<LocationDto>>> GetLocations()
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var locationDtos = await locationRepository.GetLocationsAsync(userAuthDto.Id);

                return Ok(locationDtos);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get user's location by Id.
        /// </summary>
        /// <returns>Returns location DTO object.</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for the location.</exception>
        [HttpGet("{locationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<LocationDto>> GetLocation(int locationId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await locationRepository.IsLocationExistAsync(locationId);

                await locationRepository.IsOwnerOfTheLocationAsync(userAuthDto.Id, locationId);

                var locationDto = await locationRepository.GetLocationAsync(locationId);

                return Ok(locationDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region UPDATE

        /// <summary>
        /// Updates the specified location.
        /// </summary>
        /// <param name="infoSheetUpdateDto">The DTO containing updated location data.</param>
        /// <returns>Returns the LocationDto of the updated location.</returns>
        /// <exception cref="Exception">Throw if there is an error when updating the location.</exception>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<LocationDto>> UpdateLocation([FromForm] LocationUpdateDto locationUpdateDto)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await locationRepository.IsLocationExistAsync(locationUpdateDto.Id);

                await locationRepository.IsOwnerOfTheLocationAsync(userAuthDto.Id, locationUpdateDto.Id);

                var locationUpdated = await locationRepository.UpdateLocationAsync(locationUpdateDto);

                return Ok(locationUpdated);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Delete a location by its Id.
        /// </summary>
        /// <param name="infoSheetId">The Id of the info sheet to delete.</param>
        /// <returns>Returns the LocationDto of the deleted location.</returns>
        /// <exception cref="Exception">Throw if there is an error when deleting the location.</exception>
        [HttpDelete("{locationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<LocationDto>> DeleteLocation(int locationId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await locationRepository.IsLocationExistAsync(locationId);

                await locationRepository.IsOwnerOfTheLocationAsync(userAuthDto.Id, locationId);

                LocationDto locationDto = await locationRepository.DeleteLocationAsync(locationId);

                return Ok(locationDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region UTILS

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
