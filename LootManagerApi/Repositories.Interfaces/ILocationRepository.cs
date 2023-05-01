using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities.logistics;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        // CREATE
        Task<LocationDto> CreateLocationByUserIdAsync(int userId);

        // READ
        Task<LocationAddressDto> GetLocationAddressAsync(int locationId);

        Task<List<LocationDto>> GetLocationsAsync(int userId);
        Task<LocationDto> GetLocationAsync(int locationId);

        // UPDATE
        Task<LocationDto> UpdateLocationByIdAsync(int locationId);

        // DELETE
        Task<LocationDto> DeleteLocationAsync(int locationId);

        // UTILS
        Task<bool> IsLocationExistAsync(int locationId);
        Task<bool> CheckOwnerOfLocationAsync(int userId, int locationId);
    }
}
