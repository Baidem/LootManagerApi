using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities.logistics;
using LootManagerApi.Exceptions;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

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

        public async Task<LocationDto> CreateLocationByUserIdAsync(int userId)
        {
            try
            {
                Location location = new() { UserId = userId, CreatedAt = DateTime.UtcNow };

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

        public async Task<List<LocationAddressDto>> GetLocationDtoListByUserId(int userId)
        {
            var user = await context.Users
                .Include(user => user.Houses)
                .Include(user => user.Rooms)
                .Include(user => user.Furnitures)
                .Include(user => user.Shelves)
                .Include(user => user.Positions)
                .FirstAsync(user => user.Id == userId);

            var locations = await context.Locations
                .Include(location => location.House)
                .Include(location => location.Room)
                .Include(location => location.Furniture)
                .Include(location => location.Shelf)
                .Include(location => location.Position)
                .Where(location => location.UserId == userId)
                .ToListAsync();

            var locationDtoList = locations.Select(l => new LocationAddressDto(l, user)).ToList();

            return locationDtoList;
        }


        public async Task<LocationAddressDto> GetLocationAddressAsync(int locationId)
        {
            var location = await context.Locations
                .Include(location => location.House)
                .Include(location => location.Room)
                .Include(location => location.Furniture)
                .Include(location => location.Shelf)
                .Include(location => location.Position)
                .FirstAsync(l => l.Id == locationId);

            var user = await context.Users
                .Include(user => user.Houses)
                .Include(user => user.Rooms)
                .Include(user => user.Furnitures)
                .Include(user => user.Shelves)
                .Include(user => user.Positions)
                .FirstAsync(user => user.Id == location.UserId);

            return new LocationAddressDto(location, user);
        }

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

        // TODO Implement UpdateLocationByIdAsync
        public async Task<LocationDto> UpdateLocationByIdAsync(int locationId)
        {
            throw new NotSupportedException();
            //Location location = await context.Locations.FirstAsync(l => l.Id == locationId);

            //location.UpdatedAt = DateTime.UtcNow;

            //await context.SaveChangesAsync();

            //return new LocationDto(location);
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
            return await context.Locations.AnyAsync(l => l.Id == locationId);

            throw new Exception($"This location does not exist in the database. Location Id  : {locationId}");
        }

        public async Task<bool> CheckOwnerOfLocationAsync(int userId, int locationId)
        {
            var res = await context.Locations.AnyAsync(l => l.UserId == userId && l.Id == locationId);
            if (res == false)
                throw new Exception($"This user cannot access this location. User Id : {userId}. Location Id : {locationId}");

            return res;
        }

        #endregion
    }
}
