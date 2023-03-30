using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string? House { get; set; }
        public string? Room { get; set; }
        public string? Furniture { get; set; }
        public string? Shelf { get; set; }
        public int Position { get; set; }

        // Navigation properties
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        //public List<ElementLocation>? ElementLocations { get; set; }
        public List<Element> Elements { get; set; }


        public override string? ToString()
        {
            return base.ToString();
        }

        public string GetLocationAddress()
        {
            return $"{House}-{Room}-{Furniture}-{Shelf}-{Position}";
        }
    }
}
