using LootManagerApi.Entities.logistics;
using LootManagerApi.Entities;


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
                Position_id = location.Position?.Id;
                Position_name = location.Position?.Name;
                Position_indice = location.Position?.Indice;

                Shelf_id = user?.Positions?
                    .Where(p => p.Id == Position_id)
                    .Select(p => p.ShelfId)
                    .First();                
                Shelf_name = user?.Shelves?
                    .Where(s => s.Id == Shelf_id)
                    .Select(s => s.Name)
                    .First();
                Shelf_indice = user?.Shelves?
                    .Where(s => s.Id == Shelf_id)
                    .Select(s => s.Indice)
                    .First();
                Furniture_id = user?.Shelves?
                    .Where(s => s.Id == Shelf_id)
                    .Select(s => s.FurnitureId)
                    .First();
                Furniture_name = user?.Furnitures?
                    .Where(f => f.Id == Furniture_id)
                    .Select(f => f.Name)
                    .First();
                Furniture_indice = user?.Furnitures?
                    .Where(f => f.Id == Furniture_id)
                    .Select(f => f.Indice)
                    .First();
                Room_id = user?.Furnitures?
                    .Where(f => f.Id == Furniture_id)
                    .Select(f => f.RoomId)
                    .First();
                Room_name = user?.Rooms?
                    .Where(r => r.Id == Room_id)
                    .Select(r => r.Name)
                    .First();

                Room_indice = user?.Rooms?
                    .Where(r => r.Id == Room_id)
                    .Select(r => r.Indice)
                    .First();

                House_id = user?.Rooms?
                    .Where(r => r.Id == Room_id)
                    .Select(r => r.HouseId)
                    .First();
                House_name = user?.Houses?
                    .Where(h => h.Id == House_id)
                    .Select(h => h.Name)
                    .First();
                House_indice = user?.Houses?
                    .Where(h => h.Id == House_id)
                    .Select(h => h.Indice)
                    .First();
            }
            else if (location.Shelf != null)
            {
                Shelf_id = location.Shelf?.Id;
                Shelf_name = location.Shelf?.Name;
                Shelf_indice = location.Shelf?.Indice;

                Furniture_id = user?.Shelves?
                    .Where(s => s.Id == Shelf_id)
                    .Select(s => s.FurnitureId)
                    .First();
                Furniture_name = user?.Furnitures?
                    .Where(f => f.Id == Furniture_id)
                    .Select(f => f.Name)
                    .First();
                Furniture_indice = user?.Furnitures?
                    .Where(f => f.Id == Furniture_id)
                    .Select(f => f.Indice)
                    .First();
                Room_id = user?.Furnitures?
                    .Where(f => f.Id == Furniture_id)
                    .Select(f => f.RoomId)
                    .First();
                Room_name = user?.Rooms?
                    .Where(r => r.Id == Room_id)
                    .Select(r => r.Name)
                    .First();
                Room_indice = user?.Rooms?
                    .Where(r => r.Id == Room_id)
                    .Select(r => r.Indice)
                    .First();
                House_id = user?.Rooms?
                    .Where(r => r.Id == Room_id)
                    .Select(r => r.HouseId)
                    .First();
                House_name = user?.Houses?
                    .Where(h => h.Id == House_id)
                    .Select(h => h.Name)
                    .First();
                House_indice = user?.Houses?
                    .Where(h => h.Id == House_id)
                    .Select(h => h.Indice)
                    .First();
            }
            else if (location.Furniture != null)
            {
                Furniture_id = location.Furniture?.Id;
                Furniture_name = location.Furniture?.Name;
                Furniture_indice = location.Furniture?.Indice;

                Room_id = user?.Furnitures?
                    .Where(f => f.Id == Furniture_id)
                    .Select(f => f.RoomId)
                    .First();
                Room_name = user?.Rooms?
                    .Where(r => r.Id == Room_id)
                    .Select(r => r.Name)
                    .First();
                Room_indice = user?.Rooms?
                    .Where(r => r.Id == Room_id)
                    .Select(r => r.Indice)
                    .First();
                House_id = user?.Rooms?
                    .Where(r => r.Id == Room_id)
                    .Select(r => r.HouseId)
                    .First();
                House_name = user?.Houses?
                    .Where(h => h.Id == House_id)
                    .Select(h => h.Name)
                    .First();
                House_indice = user?.Houses?
                    .Where(h => h.Id == House_id)
                    .Select(h => h.Indice)
                    .First();
            }
            else if (location.Room != null)
            {
                Room_id = location.Room?.Id;
                Room_name = location.Room?.Name;
                Room_indice = location.Room?.Indice;

                House_id = user?.Rooms?
                    .Where(r => r.Id == Room_id)
                    .Select(r => r.HouseId)
                    .First();
                House_name = user?.Houses?
                    .Where(h => h.Id == House_id)
                    .Select(h => h.Name)
                    .First();
                House_indice = user?.Houses?
                    .Where(h => h.Id == House_id)
                    .Select(h => h.Indice)
                    .First();
            }
            else if (location.House != null)
            {
                House_id = location.House?.Id;
                House_name = location.House?.Name;
                House_indice = location.House?.Indice;
            }
        }

        #endregion

    }
}
