using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LootManagerApi.Dto;
using System.Reflection;
using System.Text;
using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Entities.logistics
{
    public class Location
    {
        #region PROPERTIES

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #endregion

        #region NAVIGATION PROPERTIES (8)

        // One Location? To Many Element?
        public List<Element>? Elements { get; set; }

        // One House To Many Location
        public int HouseId { get; set; }
        public House House { get; set; }

        // One Room? To Many Location
        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        // One Furniture? To Many Location
        public int? FurnitureId { get; set; }
        public Furniture? Furniture { get; set; }

        // One Shelf? To Many Location
        public int? ShelfId { get; set; }
        public Shelf? Shelf { get; set; }

        // One Position? To One Location
        public int? PositionId { get; set; }
        public Position? Position { get; set; }

        // One User To Many Location
        public int? UserId { get; set; }
        public User? User { get; set; }

        // One DefaultLocation To One User
        public DefaultLocation? DefaultLocation { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Location()
        {
        }

        public Location(LocationCreateDto locationCreateDto)
        {
            UserId = locationCreateDto.UserId;
            HouseId = locationCreateDto.HouseId;
            RoomId = locationCreateDto.RoomId;
            FurnitureId = locationCreateDto.FurnitureId;
            ShelfId = locationCreateDto.ShelfId;
            PositionId = locationCreateDto.PositionId;
            CreatedAt = DateTime.UtcNow;
        }

        #endregion

        #region METHODS

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name}: {prop.GetValue(this)}");
            }
            return sb.ToString();
        }

        #endregion

    }
}
