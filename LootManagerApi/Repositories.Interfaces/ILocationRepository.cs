using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        // CREATE
        Task<LocationDto> CreateLocationAsync(LocationCreateDto locationCreateDto);

        // READ
        Task<LocationAddressDto> GetLocationAddressAsync(int locationId);

        Task<List<LocationDto>> GetLocationsAsync(int userId);
        Task<LocationDto> GetLocationAsync(int locationId);

        // UPDATE
        Task<LocationDto> UpdateLocationAsync(LocationUpdateDto locationUpdateDto);

        // DELETE
        Task<LocationDto> DeleteLocationAsync(int locationId);

        // UTILS
        Task<bool> IsLocationExistAsync(int locationId);
        Task<bool> CheckOwnerOfLocationAsync(int userId, int locationId);
        Task<bool> CheckLocationCreateDto(LocationCreateDto locationCreateDto);
        Task<bool> CheckLocationUpdateDtoAsync(LocationUpdateDto locationUpdateDto);
    }
}
