using LootManagerApi.Dto;
using LootManagerApi.Entities;
using LootManagerApi.Repositories.Interfaces;

namespace LootManagerApi.Repositories
{
    public class ElementRepository : IElementRepository
    {
        #region DECLARATION
        LootManagerContext context;
        ILogger<ElementRepository> logger;

        #endregion
        #region CONSTRUCTOR
        public ElementRepository(LootManagerContext context, ILogger<ElementRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public ElementCreateDto CreateElement(ElementCreateDto elementCreateDto, int userId)
        {
            Element element = new Element(elementCreateDto, userId);
            context.Elements.Add(element);
            context.SaveChanges();
            return elementCreateDto;
        }
        #endregion

    }
}
