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
        #endregion

    }
}
