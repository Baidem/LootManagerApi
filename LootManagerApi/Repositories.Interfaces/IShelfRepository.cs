using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IShelfRepository
    {
        // CREATE
        Task<ShelfDto> CreateShelfByDtoAsync(ShelfCreateDto shelfCreateDto, LocationDto location);
        Task<FurnitureDto> GenerateShelvesAsync(FurnitureDto furnitureDto, int numberOfShelves, int numberOfPositionsPerShelf);

        // UTILS
        Task<int> AutoIndiceShelf_LastAddOne(int furnitureId);
        Task<bool> CheckTheOwnerOfTheShelfAsync(int userId, int shelfId);
        Task<ShelfCreateDto> CheckIndiceFreeOrUpdateDefaultIndice(ShelfCreateDto shelfCreateDto);

    }
}
