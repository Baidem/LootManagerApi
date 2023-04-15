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

                var elementDto = await elementRepository.CreateElementAsync(elementCreateDto, userAuthDto.Id.Value);

                return Ok(elementDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region READ

        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<ElementDto>>> GetElements()
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                var elementDtos = await elementRepository.GetElementsAsync(userAuthDto.Id.Value);

                return Ok(elementDtos);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{elementId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ElementDto>> GetElement(int elementId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();

                await elementRepository.IsOwnerOfTheElementAsync(userAuthDto.Id.Value, elementId);

                var elementDto = await elementRepository.GetElementAsync(elementId);

                return Ok(elementDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #endregion

        #region PUT ELEMENT
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Element>> UpdateElement([FromForm] ElementUpdateDto elementUpdateDto)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();
                int n = userAuthDto.Id.Value;

                var elementUpdate = new ElementUpdateDto()
                {
                    Id = elementUpdateDto.Id,
                    Name = elementUpdateDto.Name,
                    Description = elementUpdateDto.Description,
                    Type = elementUpdateDto.Type
                };
                var elementUpdated = await elementRepository.UpdateElementAsync(elementUpdate, n);
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
                int n = userAuthDto.Id.Value;
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
