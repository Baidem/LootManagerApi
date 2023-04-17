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
