using LootManagerApi.Dto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<LocationDto> CreateLocationAsync(LocationCreateDto locationCreateDto, int userId);
        Task<List<LocationDto>> GetLocationsAsync(int userId);
    }
}
