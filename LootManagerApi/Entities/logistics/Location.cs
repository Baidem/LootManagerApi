using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LootManagerApi.Dto;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Entities.logistics
{
    public class Location
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // NAVIGATION PROPERTIES (7)

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

        public Location()
        {
        }

        //public Location(LocationCreateDto locationCreateDto, int userId)
        //{
        //    House = locationCreateDto.House;
        //    Room = locationCreateDto.Room;
        //    Furniture = locationCreateDto.Furniture;
        //    Shelf = locationCreateDto.Shelf;
        //    Position = locationCreateDto.Position;
        //    UserId = userId;
        //}

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name}: {prop.GetValue(this)}");
            }
            return sb.ToString();
        }

        public string GetLocationAddress()
        {
            return $"{House}-{Room}-{Furniture}-{Shelf}-{Position}";
        }
    }
}
