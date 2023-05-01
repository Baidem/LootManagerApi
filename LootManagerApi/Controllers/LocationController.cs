using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Repositories.Interfaces;
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

        #region READ

        /// <summary>
        /// Get the location address.
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>LocationAddressDto</returns>
        /// <exception cref="Exception">Throw if there is an error when searching address.</exception>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<LocationAddressDto>> GetLocationAddress(int locationId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await locationRepository.CheckOwnerOfLocationAsync(locationId, userAuthDto.Id);

                var locationAddressDto = await locationRepository.GetLocationAddressAsync(locationId);

                return Ok(locationAddressDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


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
        /// <param name="locationId"></param>
        /// <returns>LocationDto</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for the location.</exception>
        [HttpGet("{locationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<LocationDto>> GetLocation(int locationId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await locationRepository.CheckOwnerOfLocationAsync(userAuthDto.Id, locationId);

                var locationDto = await locationRepository.GetLocationAsync(locationId);

                return Ok(locationDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region DELETE

        /// <summary>
        /// -Admin Fonction-
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

                Utils.UtilsRole.CheckOnlyAdmin(userAuthDto);

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
