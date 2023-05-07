using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Dto;
using LootManagerApi.Entities.logistics;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IPositionRepository
    {
        // CREATE
        Task<PositionDto> CreatePositionByDtoAsync(PositionCreateDto positionCreateDto, LocationDto locationDto);
        Task<ShelfDto> GeneratePositionsAsync(ShelfDto shelfDto, int numberOfPositions);

        // READ
        Task<PositionDto> GetPositionDtoByIdAsync(int positionId);
        Task<List<PositionDto>> GetListOfPositionDtoByUserIdAsync(int userId, int numberOfElements);
        Task<List<PositionDto>> GetListOfPositionDtoByShelfIdAsync(int shelfId, int numberOfElements);
        Task<List<PositionDto>> GetListOfPositionDtoByNameSearchAsync(int userId, string nameSearch, int numberOfElements);


        // UTILS
        Task<int> AutoIndicePosition_LastAddOne(int shelfId);
        Task<PositionCreateDto> CheckIndiceFreeOrUpdateDefaultIndice(PositionCreateDto positionCreateDto);
        Task<bool> CheckTheOwnerOfThePositionAsync(int userId, int positionId);

    }
}
