using LootManagerApi.Dto;
using LootManagerApi.Entities;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class InfoSheetRepository : IInfoSheetRepository
    {
        #region DECLARATIONS
        LootManagerContext context;
        ILogger<InfoSheetRepository> logger;
        #endregion

        #region CONSTRUCTOR
        public InfoSheetRepository(LootManagerContext context, ILogger<InfoSheetRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        #endregion

        #region CREATE USER
        public async Task<InfoSheetSummaryDto> CreateInfoSheetAsync(InfoSheetCreateDto infoSheetCreateDto, int userId)
        {
            try
            {
                string? authorSignature = context.Users.Where(u => u.Id == userId).Select(a => a.AuthorSignature).FirstAsync().ToString();
                var infoSheet = new InfoSheet(infoSheetCreateDto, authorSignature);
                await context.InfoSheets.AddAsync(infoSheet);
                await context.SaveChangesAsync();
                return new InfoSheetSummaryDto(infoSheet);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the info sheet.", ex);
            }
        }
        #endregion
    }
}
