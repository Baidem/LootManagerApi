using LootManagerApi.Entities.logistics;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class LocationDto
    {
        public int LocationId { get; set; }
        public int UserId { get; set; }
        public int? HouseId { get; set; }
        public int? RoomId { get; set; }
        public int? FurnitureId { get; set; }
        public int? ShelfId { get; set; }
        public int? PositionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public LocationDto()
        {
        }

        public LocationDto(Location location)
        {
            LocationId = location.Id;
            UserId = location.UserId.Value;
            CreatedAt = location.CreatedAt;
            UpdatedAt = location.UpdatedAt;

            if (location.House != null)
                HouseId = location.House.Id;

            if (location.Room != null)
                RoomId = location.Room.Id;

            if (location.Furniture != null)
                FurnitureId = location.Furniture.Id;

            if (location.Shelf != null)
                ShelfId = location.Shelf.Id;

            if (location.Position != null)
                PositionId = location.Position.Id;

        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name}: {prop.GetValue(this)}");
            }
            return sb.ToString();
        }

    }
}
