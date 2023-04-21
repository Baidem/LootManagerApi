namespace LootManagerApi.Entities.logistics
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // NAVIGATION PROPERTIES

        // One Position? To One Location
        public Location Location { get; set; }

        // One Shelf To Many Position?
        public int ShelfId { get; set; }
    }
}
