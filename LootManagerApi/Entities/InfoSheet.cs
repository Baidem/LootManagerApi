using LootManagerApi.Dto;

namespace LootManagerApi.Entities
{
    public class InfoSheet
    {
        #region PROPERTIES

        public int Id { get; set; }
        public string? Designation { get; set; }
        public string? Reference { get; set; }
        public string? BarCode { get; set; }
        public string? WikiArticle { get; set; }
        public string? AuthorSignature { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #endregion

        #region NAVIGATION PROPERTIES (3)

        // One User To Many InfoSheet?
        public int UserId { get; set; }
        public User User { get; set; }

        // One InfoSheet? To Many Element?
        public List<Element>? Elements { get; set; }

        // Many InfoSheet? To Many Image?
        public List<Image>? Images { get; set; }

        #endregion

        #region CONSTRUCTOR

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

        #endregion
    }
}
