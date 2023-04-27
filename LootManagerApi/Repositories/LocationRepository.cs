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

        public async Task<LocationDto> CreateLocationByDtoAsync(LocationCreateDto locationCreateDto)
        {
            try
            {
                return new LocationDto(await CreateLocationAsync(new Location(locationCreateDto)));
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the location : {ex.Message}");
            }
        }

        private async Task<Location> CreateLocationAsync(Location location)
        {
            await context.Locations.AddAsync(location);

            await context.SaveChangesAsync();

            return location;
        }

        #endregion

        #region READ

        public async Task<LocationAddressDto> GetLocationAddressAsync(int locationId)
        {
            Location location = await context.Locations
                .Include(x => x.House)
                .Include(x => x.Room)
                .Include(x => x.Furniture)
                .Include(x => x.Shelf)
                .Include(x => x.Position)
                .FirstAsync(x => x.Id == locationId);

            return new LocationAddressDto(location);
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

        /// <summary>
        /// Updating an Location by an LocationUpdateDto.
        /// Only non-null data will be modified.
        /// </summary>
        /// <param name="locationUpdateDto"></param>
        /// <returns>LocationDto</returns>
        /// <exception cref="Exception"></exception>
        public async Task<LocationDto> UpdateLocationAsync(LocationUpdateDto locationUpdateDto)
        {
            try
            {
                Location location = await context.Locations.FirstAsync(l => l.Id == locationUpdateDto.LocationId);

                location.HouseId = locationUpdateDto.HouseId;

                location.RoomId = locationUpdateDto.RoomId;

                location.ShelfId = locationUpdateDto.ShelfId;

                location.PositionId = locationUpdateDto.PositionId;

                location.UpdatedAt = DateTime.UtcNow;

                return new LocationDto(await UpdateLocationAsync(location));
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the location. {ex.Message}", ex);
            }
        }

        public async Task<Location> UpdateLocationAsync(Location location)
        {
            await context.SaveChangesAsync();

            return location;
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
            return await context.Locations.AnyAsync(x => x.UserId == userId && x.Id == locationId);

            throw new Exception($"This user cannot access this location. User Id : {userId}. Location Id : {locationId}");
        }

        public async Task<bool> CheckLocationCreateDto(LocationCreateDto locationCreateDto)
        {
            try
            {
                return await CheckLegacyOfLocationAsync(new LocationLegacy(locationCreateDto));
            }
            catch (Exception ex)
            {
                throw new LegacyOfLocationException(ex.Message);
            }
        }

        public async Task<bool> CheckLocationUpdateDtoAsync(LocationUpdateDto locationUpdateDto)
        {
            try
            {
                return await CheckLegacyOfLocationAsync(new LocationLegacy(locationUpdateDto));
            }
            catch (Exception ex)
            {
                throw new LegacyOfLocationException(ex.Message);
            }

        }

        private async Task<bool> CheckLegacyOfLocationAsync(LocationLegacy locationLegacy)
        {
            var userTables = await context.Users.AsNoTracking().
                Include(u => u.Houses).
                Include(u => u.Rooms).
                Include(u => u.Furnitures).
                Include(u => u.Shelves).
                Include(u => u.Positions).
                Where(u => u.Id == locationLegacy.UserId).FirstAsync();

            if (locationLegacy.PositionId != null)
            {
                if (userTables.Positions == null || !userTables.Positions.Any(p => p.Id == locationLegacy.PositionId))
                    throw new Exception($"This position is not accessible for this user. PositionId: {locationLegacy.PositionId}; UserId: {locationLegacy.UserId};");

                if (!userTables.Positions.Any(p => p.Id == locationLegacy.PositionId && p.ShelfId == locationLegacy.ShelfId))
                    throw new Exception($"This position is not accessible for this shelf. PositionId: {locationLegacy.PositionId}; ShelfId: {locationLegacy.ShelfId};");
            }

            if (locationLegacy.ShelfId != null)
            {
                if (userTables.Shelves == null || !userTables.Shelves.Any(s => s.Id == locationLegacy.ShelfId))
                    throw new Exception($"This shelf is not accessible for this user. ShelfId: {locationLegacy.ShelfId}; UserId: {locationLegacy.UserId};");

                if (!userTables.Shelves.Any(s => s.Id == locationLegacy.ShelfId && s.FurnitureId == locationLegacy.FurnitureId))
                    throw new Exception($"This shelf is not accessible for this furniture. ShelfId: {locationLegacy.ShelfId}; FurnitureId: {locationLegacy.FurnitureId};");
            }

            if (locationLegacy.FurnitureId != null)
            {
                if (userTables.Furnitures == null || !userTables.Furnitures.Any(f => f.Id == locationLegacy.FurnitureId))
                    throw new Exception($"This furniture is not accessible for this user. FurnitureId: {locationLegacy.FurnitureId}; UserId: {locationLegacy.UserId};");

                if (!userTables.Furnitures.Any(f => f.Id == locationLegacy.FurnitureId && f.RoomId == locationLegacy.RoomId))
                    throw new Exception($"This furniture is not accessible for this room. FurnitureId: {locationLegacy.FurnitureId}; RoomId: {locationLegacy.RoomId};");
            }

            if (locationLegacy.RoomId != null)
            {
                if (userTables.Rooms == null || !userTables.Rooms.Any(r => r.Id == locationLegacy.RoomId))
                    throw new Exception($"This room is not accessible for this user. RoomId: {locationLegacy.RoomId}; UserId: {locationLegacy.UserId};");

                if (!userTables.Rooms.Any(r => r.Id == locationLegacy.RoomId && r.HouseId == locationLegacy.HouseId))
                    throw new Exception($"This room is not accessible for this house. RoomId: {locationLegacy.RoomId}; HouseId: {locationLegacy.HouseId};");
            }

            if (!userTables.Houses.Any(h => h.Id == locationLegacy.HouseId))
                throw new Exception($"This house is not accessible for this user. HouseId: {locationLegacy.HouseId}; UserId: {locationLegacy.UserId};");

            return true;
        }

        private class LocationLegacy
        {
            [Required] public int UserId { get; set; }
            [Required] public int HouseId { get; set; }
            public int? RoomId { get; set; }
            public int? FurnitureId { get; set; }
            public int? ShelfId { get; set; }
            public int? PositionId { get; set; }

            public LocationLegacy(LocationUpdateDto locationUpdateDto)
            {
                UserId = locationUpdateDto.UserId;
                HouseId = locationUpdateDto.HouseId;
                RoomId = locationUpdateDto.RoomId;
                FurnitureId = locationUpdateDto.FurnitureId;
                ShelfId = locationUpdateDto.ShelfId;
                PositionId = locationUpdateDto.PositionId;
            }

            public LocationLegacy(LocationCreateDto locationCreateDto)
            {
                UserId = locationCreateDto.UserId;
                HouseId = locationCreateDto.HouseId;
                RoomId = locationCreateDto.RoomId;
                FurnitureId = locationCreateDto.FurnitureId;
                ShelfId = locationCreateDto.ShelfId;
                PositionId = locationCreateDto.PositionId;
            }
        }

        #endregion
    }
}
