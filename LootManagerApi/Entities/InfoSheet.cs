namespace LootManagerApi.Entities
{
    public class InfoSheet
    {
        public int Id { get; set; }
        public string? Designation { get; set; }
        public string? Reference { get; set; }
        public string? BarCode { get; set; }
        public string? WikiArticle { get; set; }

        // Navigation properties
        public List<Element> Elements { get; set; }

    }
}
