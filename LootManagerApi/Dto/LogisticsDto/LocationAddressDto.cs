using LootManagerApi.Entities.logistics;
using LootManagerApi.Entities;


namespace LootManagerApi.Dto.LogisticsDto
{
    public class LocationAddressDto
    {
        #region PROPERTIES

        public int Location_Id { get; set; }

        public int? House_Id { get; set; }
        public string? House_Name { get; set; }
        public int? House_Indice { get; set; }

        public int? Room_Id { get; set; }
        public string? Room_Name { get; set; }
        public int? Room_Indice { get; set; }

        public int? Furniture_Id { get; set; }
        public string? Furniture_Name { get; set; }
        public int? Furniture_Indice { get; set; }

        public int? Shelf_Id { get; set; }
        public string? Shelf_Name { get; set; }
        public int? Shelf_Indice { get; set; }

        public int? Position_Id { get; set; }
        public string? Position_Name { get; set; }
        public int? Position_Indice { get; set; }

        public LocationAddressDto()
        {
        }

        public LocationAddressDto(Location location, User user)
        {
            Location_Id = location.Id;
            if (location.Position != null)
            {
                Position_Id = location.Position?.Id;
                Position_Name = location.Position?.Name;
                Position_Indice = location.Position?.Indice;

                Shelf_Id = user?.Positions?
                    .Where(p => p.Id == Position_Id)
                    .Select(p => p.ShelfId)
                    .First();
                
                Shelf_Name = user?.Shelves?
                    .Where(s => s.Id == Shelf_Id)
                    .Select(s => s.Name)
                    .First();

                Shelf_Indice = user?.Shelves?
                    .Where(s => s.Id == Shelf_Id)
                    .Select(s => s.Indice)
                    .First();

                Furniture_Id = user?.Shelves?
                    .Where(s => s.Id == Shelf_Id)
                    .Select(s => s.FurnitureId)
                    .First()
;
                Furniture_Name = user?.Furnitures?
                    .Where(f => f.Id == Furniture_Id)
                    .Select(f => f.Name)
                    .First();

                Furniture_Indice = user?.Furnitures?
                    .Where(f => f.Id == Furniture_Id)
                    .Select(f => f.Indice)
                    .First();

                Room_Id = user?.Furnitures?
                    .Where(f => f.Id == Furniture_Id)
                    .Select(f => f.RoomId)
                    .First()
;
                Room_Name = user?.Rooms?
                    .Where(r => r.Id == Room_Id)
                    .Select(r => r.Name)
                    .First();

                Room_Indice = user?.Rooms?
                    .Where(r => r.Id == Room_Id)
                    .Select(r => r.Indice)
                    .First();

                House_Id = user?.Rooms?
                    .Where(r => r.Id == Room_Id)
                    .Select(r => r.HouseId)
                    .First()
;
                House_Name = user?.Houses?
                    .Where(h => h.Id == House_Id)
                    .Select(h => h.Name)
                    .First();

                House_Indice = user?.Houses?
                    .Where(h => h.Id == House_Id)
                    .Select(h => h.Indice)
                    .First();
            }
            else if (location.Shelf != null)
            {
                Shelf_Id = location.Shelf?.Id;
                Shelf_Name = location.Shelf?.Name;
                Shelf_Indice = location.Shelf?.Indice;

                Furniture_Id = user?.Shelves?
                    .Where(s => s.Id == Shelf_Id)
                    .Select(s => s.FurnitureId)
                    .First()
;
                Furniture_Name = user?.Furnitures?
                    .Where(f => f.Id == Furniture_Id)
                    .Select(f => f.Name)
                    .First();

                Furniture_Indice = user?.Furnitures?
                    .Where(f => f.Id == Furniture_Id)
                    .Select(f => f.Indice)
                    .First();

                Room_Id = user?.Furnitures?
                    .Where(f => f.Id == Furniture_Id)
                    .Select(f => f.RoomId)
                    .First()
;
                Room_Name = user?.Rooms?
                    .Where(r => r.Id == Room_Id)
                    .Select(r => r.Name)
                    .First();

                Room_Indice = user?.Rooms?
                    .Where(r => r.Id == Room_Id)
                    .Select(r => r.Indice)
                    .First();

                House_Id = user?.Rooms?
                    .Where(r => r.Id == Room_Id)
                    .Select(r => r.HouseId)
                    .First()
;
                House_Name = user?.Houses?
                    .Where(h => h.Id == House_Id)
                    .Select(h => h.Name)
                    .First();

                House_Indice = user?.Houses?
                    .Where(h => h.Id == House_Id)
                    .Select(h => h.Indice)
                    .First();
            }
            else if (location.Furniture != null)
            {
                Furniture_Id = location.Furniture?.Id;
                Furniture_Name = location.Furniture?.Name;
                Furniture_Indice = location.Furniture?.Indice;

                Room_Id = user?.Furnitures?
                    .Where(f => f.Id == Furniture_Id)
                    .Select(f => f.RoomId)
                    .First()
;
                Room_Name = user?.Rooms?
                    .Where(r => r.Id == Room_Id)
                    .Select(r => r.Name)
                    .First();

                Room_Indice = user?.Rooms?
                    .Where(r => r.Id == Room_Id)
                    .Select(r => r.Indice)
                    .First();

                House_Id = user?.Rooms?
                    .Where(r => r.Id == Room_Id)
                    .Select(r => r.HouseId)
                    .First()
;
                House_Name = user?.Houses?
                    .Where(h => h.Id == House_Id)
                    .Select(h => h.Name)
                    .First();

                House_Indice = user?.Houses?
                    .Where(h => h.Id == House_Id)
                    .Select(h => h.Indice)
                    .First();
            }
            else if (location.Room != null)
            {
                Room_Id = location.Room?.Id;
                Room_Name = location.Room?.Name;
                Room_Indice = location.Room?.Indice;

                House_Id = user?.Rooms?
                    .Where(r => r.Id == Room_Id)
                    .Select(r => r.HouseId)
                    .First()
;
                House_Name = user?.Houses?
                    .Where(h => h.Id == House_Id)
                    .Select(h => h.Name)
                    .First();

                House_Indice = user?.Houses?
                    .Where(h => h.Id == House_Id)
                    .Select(h => h.Indice)
                    .First();
            }
            else if (location.House != null)
            {
                House_Id = location.House?.Id;
                House_Name = location.House?.Name;
                House_Indice = location.House?.Indice;
            }
        }

        #endregion

    }
}
