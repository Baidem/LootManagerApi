using LootManagerApi.Entities;

namespace LootManagerApi.Dto
{
    public class InfoSheetSummaryDto
    {
        public string? Designation { get; set; }
        public string? Reference { get; set; }
        public string? AuthorSignature { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public InfoSheetSummaryDto()
        {
        }

        public InfoSheetSummaryDto(InfoSheet infoSheet)
        {
            Designation = infoSheet.Designation;
            Reference = infoSheet.Reference;
            AuthorSignature = infoSheet.AuthorSignature;
            CreatedAt = infoSheet.CreatedAt;
            UpdatedAt = infoSheet.UpdatedAt;
        }
    }
}
