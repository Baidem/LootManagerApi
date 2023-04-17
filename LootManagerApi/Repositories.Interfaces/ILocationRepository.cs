using LootManagerApi.Dto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<LocationDto> CreateLocationAsync(LocationCreateDto locationCreateDto, int userId);
        Task<List<LocationDto>> GetLocationsAsync(int userId);
        Task<LocationDto> GetLocationAsync(int locationId);
        Task<bool> IsLocationExistAsync(int locationId);
        Task<bool> IsOwnerOfTheLocationAsync(int userId, int locationId);
    }
}
