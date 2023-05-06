using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IShelfRepository
    {
        // CREATE
        Task<ShelfDto> CreateShelfByDtoAsync(ShelfCreateDto shelfCreateDto, LocationDto location);
        Task<FurnitureDto> GenerateShelvesAsync(FurnitureDto furnitureDto, int numberOfShelves, int numberOfPositionsPerShelf);

        // READ
        Task<List<ShelfDto>> GetListOfShelfDtoByUserIdAsync(int userId, int numberOfElements);
        Task<List<ShelfDto>> GetListOfShelfDtoByFurnitureIdAsync(int furnitureId, int numberOfElements);


        // UTILS
        Task<int> AutoIndiceShelf_LastAddOne(int furnitureId);
        Task<bool> CheckTheOwnerOfTheShelfAsync(int userId, int shelfId);
        Task<ShelfCreateDto> CheckIndiceFreeOrUpdateDefaultIndice(ShelfCreateDto shelfCreateDto);

    }
}
