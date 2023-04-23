using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities.logistics;
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

        public async Task<LocationDto> CreateLocationAsync(LocationCreateDto locationCreateDto)
        {
            try
            {
                Location location = new Location(locationCreateDto);

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

                await context.SaveChangesAsync();

                return new LocationDto(location);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the location. {ex.Message}", ex);
            }

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

        public async Task<bool> CheckOwnerOfLocationAsync(int userId, int locationId)
        {
            await context.Locations.AnyAsync(x => x.UserId == userId && x.Id == locationId);

            return true;

            throw new Exception($"This user cannot access this location. User Id : {userId}. Location Id : {locationId}");
        }

        public async Task<bool> CheckLocationCreateDto(LocationCreateDto locationCreateDto)
        {
            try
            {
                return await CheckLocationHierarchyAsync(new LocationChain(locationCreateDto));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CheckLocationUpdateDtoAsync(LocationUpdateDto locationUpdateDto)
        {
            try
            {
                return await CheckLocationHierarchyAsync(new LocationChain(locationUpdateDto));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private async Task<bool> CheckLocationHierarchyAsync(LocationChain locationChain)
        {
            var userTables = await context.Users.AsNoTracking().
                Include(u => u.Houses).
                Include(u => u.Rooms).
                Include(u => u.Furnitures).
                Include(u => u.Shelves).
                Include(u => u.Positions).
                Where(u => u.Id == locationChain.UserId).FirstAsync();

            if (locationChain.PositionId != null)
            {
                if (userTables.Positions == null || !userTables.Positions.Any(p => p.Id == locationChain.PositionId))
                    throw new Exception("This position is not accessible for this user.");

                if (!userTables.Positions.Any(p => p.Id == locationChain.PositionId && p.ShelfId == locationChain.ShelfId))
                    throw new Exception("This position is not accessible for this shelf.");
            }

            if (locationChain.ShelfId != null)
            {
                if (userTables.Shelves == null || !userTables.Shelves.Any(s => s.Id == locationChain.ShelfId))
                    throw new Exception("This shelf is not accessible for this user.");

                if (!userTables.Shelves.Any(s => s.Id == locationChain.ShelfId && s.FurnitureId == locationChain.FurnitureId))
                    throw new Exception("This shelf is not accessible for this furniture.");
            }

            if (locationChain.FurnitureId != null)
            {
                if (userTables.Furnitures == null || !userTables.Furnitures.Any(f => f.Id == locationChain.FurnitureId))
                    throw new Exception("This furniture is not accessible for this user.");

                if (!userTables.Furnitures.Any(f => f.Id == locationChain.FurnitureId && f.RoomId == locationChain.RoomId))
                    throw new Exception("This furniture is not accessible for this room.");
            }

            if (locationChain.RoomId != null)
            {
                if (userTables.Rooms == null || !userTables.Rooms.Any(r => r.Id == locationChain.RoomId))
                    throw new Exception("This room is not accessible for this user.");

                if (!userTables.Rooms.Any(r => r.Id == locationChain.RoomId && r.HouseId == locationChain.HouseId))
                    throw new Exception("This room is not accessible for this house.");
            }

            if (!userTables.Houses.Any(h => h.Id == locationChain.HouseId))
                throw new Exception("This house is not accessible for this user.");

            return true;
        }

        private class LocationChain
        {
            [Required] public int UserId { get; set; }
            [Required] public int HouseId { get; set; }
            public int? RoomId { get; set; }
            public int? FurnitureId { get; set; }
            public int? ShelfId { get; set; }
            public int? PositionId { get; set; }

            public LocationChain(LocationUpdateDto locationUpdateDto)
            {
                UserId = locationUpdateDto.UserId;
                HouseId = locationUpdateDto.HouseId;
                RoomId = locationUpdateDto.RoomId;
                FurnitureId = locationUpdateDto.FurnitureId;
                ShelfId = locationUpdateDto.ShelfId;
                PositionId = locationUpdateDto.PositionId;
            }

            public LocationChain(LocationCreateDto locationCreateDto)
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
