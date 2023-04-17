using LootManagerApi.Dto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        // CREATE
        Task<LocationDto> CreateLocationAsync(LocationCreateDto locationCreateDto, int userId);

        // READ
        Task<List<LocationDto>> GetLocationsAsync(int userId);
        Task<LocationDto> GetLocationAsync(int locationId);

        // UPDATE
        Task<LocationDto> UpdateLocationAsync(LocationUpdateDto locationUpdateDto);

        // DELETE
        Task<LocationDto> DeleteLocationAsync(int locationId);

        // UTILS
        Task<bool> IsLocationExistAsync(int locationId);
        Task<bool> IsOwnerOfTheLocationAsync(int userId, int locationId);
    }
}
