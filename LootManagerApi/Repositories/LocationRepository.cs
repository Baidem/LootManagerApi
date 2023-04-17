using LootManagerApi.Dto;
using LootManagerApi.Entities;
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
            try
            {
                Location location = new(locationCreateDto, userId);

                await context.Locations.AddAsync(location);

                await context.SaveChangesAsync();

                return new LocationDto(location);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the location : {ex.Message}");
            }

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

        #region UTILS

        public async Task<bool> IsLocationExistAsync(int locationId)
        {
            if (await context.Locations.AnyAsync(e => e.Id == locationId))
                return true;

            throw new Exception("This item does not exist in the database.");
        }

        public async Task<bool> IsOwnerOfTheLocationAsync(int userId, int locationId)
        {
            if (await context.Locations.AnyAsync(e => e.UserId == userId && e.Id == locationId))
                return true;

            throw new Exception("This user cannot access this location.");
        }

        #endregion
    }
}
