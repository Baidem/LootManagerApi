using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class LocationUpdateDto
    {
        [Required] public int UserId { get; set; }
        [Required] public int LocationId { get; set; }
        [Required] public int HouseId { get; set; }
        public int? RoomId { get; set; }
        public int? FurnitureId { get; set; }
        public int? ShelfId { get; set; }
        public int? PositionId { get; set; }

        public LocationUpdateDto()
        {
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
