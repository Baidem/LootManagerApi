namespace LootManagerApi.Repositories.Interfaces
{
    public interface IShelfRepository
    {
        Task<bool> CheckTheOwnerOfTheShelfAsync(int userId, int shelfId);

    }
}
