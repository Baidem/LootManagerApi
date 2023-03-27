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
                var res = elementRepository.CreateElement(elementCreateDto, userAuthDto.Id.Value);
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
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<string>>> GetElements()
        {
            var identity = User?.Identity as ClaimsIdentity;
            var idCurrentUser = identity?.FindFirst(ClaimTypes.NameIdentifier);
            if (idCurrentUser == null)
            {
                return Problem("You must log in order to see your(s) element(s) !");
            }
            var currentUserId = Int32.Parse(idCurrentUser.Value);

            var element = await elementRepository.GetElementsAsync(int.Parse(idCurrentUser.Value));
            if (element == null)
            {
                return NotFound("You have zero elements.");
            }
            return Ok(element);
        }
        #endregion

        #region GET ELEMENT
        [HttpGet("{elementId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Element>> GetElement(int elementId)
        {
            var identity = User?.Identity as ClaimsIdentity;
            var idCurrentUser = identity?.FindFirst(ClaimTypes.NameIdentifier);
            if (idCurrentUser == null)
            {
                return Problem("You must log in order to see your(s) element(s) !");
            }
            var currentUserId = Int32.Parse(idCurrentUser.Value);

            var element = await elementRepository.GetElementAsync(elementId, int.Parse(idCurrentUser.Value));
            if (element == null)
            {
                return NotFound("Element wasnot found.");
            }
            return Ok(element);
        }
        #endregion

        #region PUT ELEMENT
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Element>> UpdateElement([FromForm] ElementUpdateDto elementUpdateDto)
        {
            var identity = User?.Identity as ClaimsIdentity;
            var idCurrentUser = identity?.FindFirst(ClaimTypes.NameIdentifier);
            if (idCurrentUser == null)
                return Problem("You must log in order to modify your element !");
            int userId = Int32.Parse(idCurrentUser.Value);


            var elementUpdate = new ElementUpdateDto()
            {
                Id = elementUpdateDto.Id,
                Name = elementUpdateDto.Name,
                Description = elementUpdateDto.Description,
                Type = elementUpdateDto.Type
            };
            var elementUpdated = await elementRepository.UpdateElementAsync(elementUpdate,userId);

            if (elementUpdated != null)
                return Ok(elementUpdated);
            else
                return Problem("Element wasnot modified, look at the logs !");
        }
        #endregion

        #region DELETE ELEMENT
        [HttpDelete("{elementId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<string>> DeleteElement(int elementId)
        {
            var identity = User?.Identity as ClaimsIdentity;
            var idCurrentUser = identity?.FindFirst(ClaimTypes.NameIdentifier);
            if (idCurrentUser == null)
                return Problem("You must log in order to delete your(s) element(s) !");

            var elementDeleted = await elementRepository.DeleteElementAsync(elementId, int.Parse(idCurrentUser.Value));

            if (elementDeleted != null)
                return Ok($"Element deleted: {elementDeleted.Id} {elementDeleted.Name} !");
            else
                return NotFound("Element wasnot found.");
        }
        #endregion
    }
}
