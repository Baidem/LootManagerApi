using LootManagerApi.Entities;
using LootManagerApi.Entities.logistics;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class LocationDto
    {
        public int LocationId { get; set; }
        public int UserId { get; set; }
        public int HouseId { get; set; }
        public int? RoomId { get; set; }
        public int? FurnitureId { get; set; }
        public int? ShelfId { get; set; }
        public int? PositionId { get; set; }

        public LocationDto()
        {
        }

        public LocationDto(Location location)
        {
            LocationId = location.Id;
            UserId = location.UserId.Value;
            HouseId = location.HouseId;
            RoomId = location.RoomId;
            FurnitureId = location.FurnitureId;
            ShelfId = location.ShelfId;
            PositionId = location.PositionId;
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
