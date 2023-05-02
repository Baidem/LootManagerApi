using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class ShelfRepository : IShelfRepository
    {
        #region DECLARATION

        LootManagerContext context;
        ILogger<ShelfRepository> logger;

        #endregion

        #region CONSTRUCTOR

        public ShelfRepository(LootManagerContext context, ILogger<ShelfRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        #endregion


        #region UTILS

        public async Task<bool> CheckTheOwnerOfTheShelfAsync(int userId, int shelfId)
        {
            if (await context.Shelves.AnyAsync(f => f.UserId == userId && f.Id == shelfId))
                return true;

            throw new Exception("This user cannot access this shelf.");
        }

        #endregion

    }
}
