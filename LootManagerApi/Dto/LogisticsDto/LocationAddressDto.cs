using LootManagerApi.Entities.logistics;
using LootManagerApi.Entities;
using Microsoft.IdentityModel.Tokens;
using System;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class LocationAddressDto
    {
        #region PROPERTIES

        public int Location_id { get; set; }
        public int User_id { get; set; }

        public int? House_id { get; set; }
        public string? House_name { get; set; }
        public int? House_indice { get; set; }

        public int? Room_id { get; set; }
        public string? Room_name { get; set; }
        public int? Room_indice { get; set; }

        public int? Furniture_id { get; set; }
        public string? Furniture_name { get; set; }
        public int? Furniture_indice { get; set; }

        public int? Shelf_id { get; set; }
        public string? Shelf_name { get; set; }
        public int? Shelf_indice { get; set; }

        public int? Position_id { get; set; }
        public string? Position_name { get; set; }
        public int? Position_indice { get; set; }

        #endregion

        #region CONSTRUCTORS

        public LocationAddressDto()
        {
        }

        public LocationAddressDto(Location location, User user)
        {
            Location_id = location.Id;
            User_id = user.Id;

            if (location.Position != null)
            {
                MapAddressFromPosition(location.Position, user);
            }
            else if (location.Shelf != null)
            {
                MapAddressFromShelf(location.Shelf, user);
            }
            else if (location.Furniture != null)
            {
                MapAddressFromFurniture(location.Furniture, user);
            }
            else if (location.Room != null)
            {
                MapAddressFromRoom(location.Room, user);
            }
            else if (location.House != null)
            {
                MapAddressFromHouse(location.House, user);
            }
        }
        private void MapAddressFromPosition(Position position, User user)
        {
            Position_id = position?.Id;
            Position_name = position?.Name;
            Position_indice = position?.Indice;

            var shelf = user?.Shelves?.FirstOrDefault(s => s.Id == position?.ShelfId);
            MapAddressFromShelf(shelf, user);
        }

        private void MapAddressFromShelf(Shelf shelf, User user)
        {
            Shelf_id = shelf?.Id;
            Shelf_name = shelf?.Name;
            Shelf_indice = shelf?.Indice;

            var furniture = user?.Furnitures?.FirstOrDefault(f => f.Id == shelf?.FurnitureId);
            MapAddressFromFurniture(furniture, user);
        }

        private void MapAddressFromFurniture(Furniture furniture, User user)
        {
            Furniture_id = furniture?.Id;
            Furniture_name = furniture?.Name;
            Furniture_indice = furniture?.Indice;

            var room = user?.Rooms?.FirstOrDefault(r => r.Id == furniture?.RoomId);
            MapAddressFromRoom(room, user);
        }

        private void MapAddressFromRoom(Room room, User user)
        {
            Room_id = room?.Id;
            Room_name = room?.Name;
            Room_indice = room?.Indice;

            var house = user?.Houses?.FirstOrDefault(r => r.Id == room?.HouseId);
            MapAddressFromHouse(house, user);
        }

        private void MapAddressFromHouse(House house, User user)
        {
            House_id = house?.Id;
            House_name = house?.Name;
            House_indice = house?.Indice;
        }

        #endregion

    }
}
