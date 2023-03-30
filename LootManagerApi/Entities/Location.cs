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
        public User User { get; set; }
        public int UserId { get; set; }
        public List<ElementLocation>? ElementLocations { get; set; }

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
