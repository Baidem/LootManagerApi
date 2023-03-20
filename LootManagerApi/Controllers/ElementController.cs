using LootManagerApi.Dto;
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



    }
}
