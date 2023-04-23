namespace LootManagerApi.Entities.logistics
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // NAVIGATION PROPERTIES (3)

        // One Position? To One Location
        public Location Location { get; set; }

        // One Shelf To Many Position?
        public int ShelfId { get; set; }

        // One User To Many Position
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
