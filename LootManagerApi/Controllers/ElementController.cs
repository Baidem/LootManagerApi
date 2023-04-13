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

        #region CREATE ELEMENT
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<List<ElementCreateDto>> CreateElement([FromForm] ElementCreateDto elementCreateDto)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();
                int n = userAuthDto.Id.Value;
                var res = elementRepository.CreateElement(elementCreateDto, n);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        #endregion

        #region GET ELEMENTS
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<string>>> GetElements()
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();
                int n = userAuthDto.Id.Value;
                var element = await elementRepository.GetElementsAsync(n);
                return Ok(element);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region GET ELEMENT
        [HttpGet("{elementId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Element>> GetElement(int elementId)
        {
            try
            {
                UserAuthDto userAuthDto = loadUserAuthentifiedDto();
                int n = userAuthDto.Id.Value;
                var element = await elementRepository.GetElementAsync(elementId,n);
                return Ok(element);
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
    }
}
