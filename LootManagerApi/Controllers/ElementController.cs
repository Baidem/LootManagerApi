using LootManagerApi.Dto;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace LootManagerApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class ElementController : ControllerBase
    {
        #region DECLARATIONS

        IElementRepository elementRepository;
        ILocationRepository locationRepository;

        #endregion

        #region CONSTRUCTOR

        public ElementController(IElementRepository elementRepository, ILocationRepository locationRepository)
        {
            this.elementRepository = elementRepository;
            this.locationRepository = locationRepository;
        }

        #endregion

        #region CREATE

        /// <summary>
        /// Create a new element
        /// </summary>
        /// <param name="elementCreateDto">Element creation DTO object containing element information</param>
        /// <returns>Returns the info element DTO object.</returns>
        /// <exception cref="Exception">Thrown when there is an error in creating the element.</exception>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<ElementDto>>> CreateElement([FromForm] ElementCreateDto elementCreateDto)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var elementDto = await elementRepository.CreateElementAsync(elementCreateDto, userAuthDto.Id);

                return Ok(elementDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region READ

        /// <summary>
        /// Get the current user's list of elements.
        /// </summary>
        /// <returns>Returns list of element DTO object.</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for elements.</exception>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<ElementDto>>> GetElements()
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var elementDtos = await elementRepository.GetElementsAsync(userAuthDto.Id);

                return Ok(elementDtos);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get user's element by Id.
        /// </summary>
        /// <returns>Returns element DTO object.</returns>
        /// <exception cref="Exception">Throw if there is an error when searching for the element.</exception>
        [HttpGet("{elementId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ElementDto>> GetElement(int elementId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await elementRepository.IsElementExistAsync(elementId);

                await elementRepository.IsOwnerOfTheElementAsync(userAuthDto.Id, elementId);

                var elementDto = await elementRepository.GetElementAsync(elementId);

                return Ok(elementDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region UPDATE

        /// <summary>
        /// Updates the specified element.
        /// </summary>
        /// <param name="infoSheetUpdateDto">The DTO containing updated element data.</param>
        /// <returns>Returns the ElementDto of the updated element.</returns>
        /// <exception cref="Exception">Throw if there is an error when updating the element.</exception>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ElementDto>> UpdateElement([FromForm] ElementUpdateDto elementUpdateDto)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await elementRepository.IsElementExistAsync(elementUpdateDto.Id);

                await elementRepository.IsOwnerOfTheElementAsync(userAuthDto.Id, elementUpdateDto.Id);

                var elementUpdated = await elementRepository.UpdateElementAsync(elementUpdateDto);

                return Ok(elementUpdated);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates the location of the element.
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="elementId"></param>
        /// <returns>Returns the ElementDto of the updated element.</returns>
        /// <exception cref="Exception">Throw if there is an error when updating the element.</exception>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ElementDto>> AddLocationToElement([Required] int locationId, [Required] int elementId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await locationRepository.IsLocationExistAsync(locationId);

                await elementRepository.IsElementExistAsync(elementId);

                await locationRepository.CheckOwnerOfLocationAsync(userAuthDto.Id, locationId);

                await elementRepository.IsOwnerOfTheElementAsync(userAuthDto.Id, elementId);

                var elementDto = await elementRepository.AddLocationToElementAsync(locationId, elementId);

                return Ok(elementDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Delete an element by its Id.
        /// </summary>
        /// <param name="infoSheetId">The Id of the element to delete.</param>
        /// <returns>Returns the ElementDto of the deleted element.</returns>
        /// <exception cref="Exception">Throw if there is an error when deleting the element.</exception>
        [HttpDelete("{elementId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ElementDto>> DeleteElement(int elementId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await elementRepository.IsElementExistAsync(elementId);

                await elementRepository.IsOwnerOfTheElementAsync(userAuthDto.Id, elementId);

                ElementDto elementDto = await elementRepository.DeleteElementAsync(elementId);

                return Ok(elementDto);
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
