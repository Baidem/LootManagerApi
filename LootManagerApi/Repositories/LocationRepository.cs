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

        public async Task<List<LocationBoard>> ReadLocationBoardAsync(int userId)
        {
            var board = await context.Locations
                 .Where(l => l.UserId == userId)
                 .Join(context.Users, location => location.UserId, user => user.Id, (location, user) =>
                 new
                 {
                     LocationId = location.Id,
                     UserId = user.Id,
                     UserName = user.FullName
                 })
                 .Join(context.Houses, lu => lu.LocationId, house => house.LocationId, (lu, house) =>
                 new
                 {
                     lu.LocationId,
                     lu.UserId,
                     lu.UserName,
                     HouseId = house.Id,
                     HouseName = house.Name,
                     HouseIndice = house.Indice
                 })
                 .Join(context.Rooms, luh => luh.HouseId, room => room.HouseId, (luh, room) =>
                 new
                 {
                     luh.LocationId,
                     luh.UserId,
                     luh.UserName,
                     luh.HouseId,
                     luh.HouseName,
                     luh.HouseIndice,
                     RoomId = room.Id,
                     RoomName = room.Name,
                     RoomIndice = room.Indice
                 })
                .Join(context.Furnitures, luhr => luhr.RoomId, furniture => furniture.RoomId, (luhr, furniture) =>
                new
                {
                    luhr.LocationId,
                    luhr.UserId,
                    luhr.UserName,
                    luhr.HouseId,
                    luhr.HouseName,
                    luhr.HouseIndice,
                    luhr.RoomId,
                    luhr.RoomName,
                    luhr.RoomIndice,
                    FurnitureId = furniture.Id,
                    FurnitureName = furniture.Name,
                    FurnitureIndice = furniture.Indice
                })
                 .Join(context.Shelves, luhrf => luhrf.FurnitureId, shelf => shelf.FurnitureId, (luhrf, shelf) => new
                 {
                     luhrf.LocationId,
                     luhrf.UserId,
                     luhrf.UserName,
                     luhrf.HouseId,
                     luhrf.HouseName,
                     luhrf.HouseIndice,
                     luhrf.RoomId,
                     luhrf.RoomName,
                     luhrf.RoomIndice,
                     luhrf.FurnitureId,
                     luhrf.FurnitureName,
                     luhrf.FurnitureIndice,
                     ShelfId = shelf.Id,
                     ShelfName = shelf.Name,
                     ShelfIndice = shelf.Indice
                 })
                .Join(context.Positions, luhrfs => luhrfs.ShelfId, position => position.ShelfId, (luhrfs, position) => new
                {
                    luhrfs.LocationId,
                    luhrfs.UserId,
                    luhrfs.UserName,
                    luhrfs.HouseId,
                    luhrfs.HouseName,
                    luhrfs.HouseIndice,
                    luhrfs.RoomId,
                    luhrfs.RoomName,
                    luhrfs.RoomIndice,
                    luhrfs.FurnitureId,
                    luhrfs.FurnitureName,
                    luhrfs.FurnitureIndice,
                    luhrfs.ShelfId,
                    luhrfs.ShelfName,
                    luhrfs.ShelfIndice,
                    PositionId = position.Id,
                    PositionName = position.Name,
                    PositionIndice = position.Indice,
                })
                 .ToListAsync();

            if (board.Count > 0)
            {
                return board.Select(lbl => new LocationBoard
                {
                    LocationId = lbl.LocationId,
                    UserId = lbl.UserId,
                    UserName = lbl.UserName,
                    HouseId = lbl.HouseId,
                    HouseName = lbl.HouseName,
                    HouseIndice = lbl.HouseIndice,
                    RoomId = lbl.RoomId,
                    RoomName = lbl.RoomName,
                    RoomIndice = lbl.RoomIndice,
                    FurnitureId = lbl.FurnitureId,
                    FurnitureName = lbl.FurnitureName,
                    FurnitureIndice = lbl.FurnitureIndice,
                    ShelfId = lbl.ShelfId,
                    ShelfName = lbl.ShelfName,
                    ShelfIndice = lbl.ShelfIndice,
                    PositionId = lbl.PositionId,
                    PositionName = lbl.PositionName,
                    PositionIndice = lbl.PositionIndice,
                }).ToList();
            }
            else
            {
                throw new Exception($"You have zero houses in your collection actually.");
            }

            throw new NotImplementedException();
        }


        public async Task<LocationAddressDto> GetLocationAddressAsync(int locationId)
        {
            // TODO Implement GetLocationAddressAsync
            throw new NotImplementedException();
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
            return await context.Locations.AnyAsync(x => x.UserId == userId && x.Id == locationId);

            throw new Exception($"This user cannot access this location. User Id : {userId}. Location Id : {locationId}");
        }

        #endregion
    }
}
