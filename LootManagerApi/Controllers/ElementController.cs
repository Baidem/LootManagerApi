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
    }
}
