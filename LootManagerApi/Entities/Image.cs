namespace LootManagerApi.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Caption { get; set; }

        // Navigation properties
        public List<Element>? Elements { get; set; }
        public List<InfoSheet>? InfoSheets { get; set; }
    }
}
