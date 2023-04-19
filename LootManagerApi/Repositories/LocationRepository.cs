using LootManagerApi.Dto;
using LootManagerApi.Entities.logistics;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        #region DECLARATION

        LootManagerContext context;
        ILogger<LocationRepository> logger;

        #endregion

        #region CONSTRUCTOR

        public LocationRepository(LootManagerContext context, ILogger<LocationRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        #endregion

        #region CREATE

        public async Task<LocationDto> CreateLocationAsync(LocationCreateDto locationCreateDto, int userId)
        {
            //try
            //{
            //    Location location = new(locationCreateDto, userId);

            //    await context.Locations.AddAsync(location);

            //    await context.SaveChangesAsync();

            //    return new LocationDto(location);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception($"An error occurred while creating the location : {ex.Message}");
            //}
            throw new NotImplementedException();

        }

        #endregion

        #region READ

        public async Task<List<LocationDto>> GetLocationsAsync(int userId)
        {
            var locationDtos = await context.Locations.Where(l => l.UserId == userId).Select(l => new LocationDto(l)).ToListAsync();

            if (locationDtos.Any())
                return locationDtos;

            throw new Exception($"You have zero locations in your collection actually.");
        }

        public async Task<LocationDto> GetLocationAsync(int locationId)
        {
            var locationDtos = await context.Locations.Where(e => e.Id == locationId).Select(e => new LocationDto(e)).FirstOrDefaultAsync();

            if (locationDtos != null)
                return locationDtos;

            throw new Exception($"Location was not found.");
        }

        #endregion

        #region UPDATE

        /// <summary>
        /// Asynchronous method of updating an Location by an LocationUpdateDto.
        /// Id required to find the location to be updated.
        /// Only non-null data will be modified.
        /// </summary>
        /// <param name="locationUpdateDto"></param>
        /// <returns>LocationDto</returns>
        /// <exception cref="Exception"></exception>
        public async Task<LocationDto> UpdateLocationAsync(LocationUpdateDto locationUpdateDto)
        {
            //try
            //{
            //    if (locationUpdateDto.House == null && locationUpdateDto.Room == null && locationUpdateDto.Furniture == null && locationUpdateDto.Shelf == null && locationUpdateDto.Position == null)
            //        throw new Exception("No changes needed.");

            //    Location location = await context.Locations.FirstAsync(e => e.Id == locationUpdateDto.Id);

            //    if (locationUpdateDto.House != null)
            //        location.House = locationUpdateDto.House;

            //    if (locationUpdateDto.Room != null)
            //        location.Room = locationUpdateDto.Room;

            //    if (locationUpdateDto.Shelf != null)
            //        location.Shelf = locationUpdateDto.Shelf;

            //    if (locationUpdateDto.Position != null)
            //        location.Position = locationUpdateDto.Position;

            //    await context.SaveChangesAsync();

            //    return new LocationDto(location);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception($"An error occurred while updating the location. {ex.Message}", ex);
            //}

            throw new NotImplementedException();
        }

        #endregion

        #region DELETE

        public async Task<LocationDto> DeleteLocationAsync(int locationId)
        {
            try
            {
                var location = await context.Locations.FirstAsync(l => l.Id == locationId);

                context.Locations.Remove(location);

                await context.SaveChangesAsync();

                return new LocationDto(location);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the location. {ex.Message}", ex);
            }
        }

        #endregion

        #region UTILS

        public async Task<bool> IsLocationExistAsync(int locationId)
        {
            if (await context.Locations.AnyAsync(l => l.Id == locationId))
                return true;

            throw new Exception($"This location does not exist in the database. Location Id  : {locationId}");
        }

        public async Task<bool> IsOwnerOfTheLocationAsync(int userId, int locationId)
        {
            if (await context.Locations.AnyAsync(l => l.UserId == userId && l.Id == locationId))
                return true;

            throw new Exception($"This user cannot access this location. User Id : {userId}. Location Id : {locationId}");
        }

        #endregion
    }
}
