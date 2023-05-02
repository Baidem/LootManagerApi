using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Dto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IPositionRepository
    {
        // CREATE
        Task<PositionDto> CreatePositionByDtoAsync(PositionCreateDto positionCreateDto, LocationDto locationDto);



        // UTILS
        Task<int> AutoIndicePosition_LastAddOne(int shelfId);
        Task<PositionCreateDto> CheckIndiceFreeOrUpdateDefaultIndice(PositionCreateDto positionCreateDto);


    }
}
