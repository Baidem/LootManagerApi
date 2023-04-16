using LootManagerApi.Dto;
using LootManagerApi.Entities;
using LootManagerApi.Repositories;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LootManagerApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class ElementController : ControllerBase
    {
        #region DECLARATIONS
        IElementRepository elementRepository;
        #endregion

        #region CONSTRUCTOR
        public ElementController(IElementRepository elementRepository)
        {
            this.elementRepository = elementRepository;
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
        /// <returns>An ActionResult containing the updated element DTO.</returns>
        /// <exception cref="Exception">Throw if there is an error when updating the element.</exception>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ElementDto>> UpdateElement([FromForm] ElementUpdateDto elementUpdateDto)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await elementRepository.IsOwnerOfTheElementAsync(userAuthDto.Id, elementUpdateDto.Id);

                var elementUpdated = await elementRepository.UpdateElementAsync(elementUpdateDto);

                return Ok(elementUpdated);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region DELETE ELEMENT
        [HttpDelete("{elementId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<string>> DeleteElement(int elementId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();
                int n = userAuthDto.Id;
                var element = await elementRepository.DeleteElementAsync(elementId, n);
                return Ok($"Element deleted: {element.Id} {element.Name} !");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region LOG

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
