using LootManagerApi.Dto;

namespace LootManagerApi.Entities
{
    public class InfoSheet
    {
        public int Id { get; set; }
        public string? Designation { get; set; }
        public string? Reference { get; set; }
        public string? BarCode { get; set; }
        public string? WikiArticle { get; set; }
        public string? AuthorSignature { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public List<Element>? Elements { get; set; }
        public List<Image>? Images { get; set; }
        public int UserId { get; set; }

        public InfoSheet()
        {
        }

        public InfoSheet(InfoSheetCreateDto infoSheetCreateDto, string? authorSignature, int userId)
        {
            Designation = infoSheetCreateDto.Designation;
            Reference = infoSheetCreateDto.Reference;
            BarCode = infoSheetCreateDto.BarCode;
            WikiArticle = infoSheetCreateDto.WikiArticle;
            AuthorSignature = authorSignature;
            CreatedAt = DateTime.UtcNow;
            UserId = userId;
        }
    }
}
