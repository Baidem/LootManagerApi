namespace LootManagerApi.Entities.logistics
{
    public class Shelf
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public int NumberOfPositions { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // NAVIGATION PROPERTIES (3)

        // One Shelf? To Many Location
        public List<Location> Locations { get; set; }

        // One Furniture To Many Shelf?
        public int FurnitureId { get; set; }
        public Furniture Furniture { get; set; }

        // One Shelf To Many Position?
        public List<Position>? Positions { get; set; }

        // One User To Many Shelf
        public int? UserId { get; set; }
        public User? User { get; set; }

    }
}
