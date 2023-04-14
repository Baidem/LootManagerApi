using LootManagerApi.Dto;
using LootManagerApi.Entities;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        #region READ

        public async Task<List<InfosheetIdAndDesignation>> GetAllInfoSheetByUserIdAsync(int userId)
        {
            try
            {
                var list = await context.InfoSheets.Where(i => i.UserId == userId).Select(i => new InfosheetIdAndDesignation(i)).ToListAsync();
                if (list.Count == 0)
                {
                    throw new Exception("The list is empty.");
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred when creating the information sheet list.", ex);
            }
        }

        public async Task<InfoSheet> GetInfoSheetByIdAsync(int infoSheetId)
        {
            try
            {
                var infoSheet = await context.InfoSheets.FirstAsync(i => i.Id == infoSheetId);
                return infoSheet;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while searching for the information sheet.", ex);
            }
        }

        #endregion

        #region Utils

        public async Task<bool> IsInfoSheetExistAsync(int infoSheetId)
        {
            if (await context.InfoSheets.AnyAsync(i => i.Id == infoSheetId))
            {
                return true;
            }
            throw new Exception("This information sheet does not exist in the database.");
        }

        #endregion
    }
}
