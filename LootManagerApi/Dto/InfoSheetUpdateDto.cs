namespace LootManagerApi.Dto
{
    public class InfoSheetUpdateDto
    {
        public int InfoSheetId { get; set; }
        public string? Designation { get; set; }
        public string? Reference { get; set; }
        public string? BarCode { get; set; }
        public string? WikiArticle { get; set; }
        public string? AuthorSignature { get; set; }

    }
}
