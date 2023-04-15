using LootManagerApi.Dto;
using LootManagerApi.Entities;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

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

        #region CREATE

        public async Task<InfoSheetSummaryDto> CreateInfoSheetAsync(InfoSheetCreateDto infoSheetCreateDto, int userId)
        {
            try
            {
                var authorSignature = context.Users.Where(u => u.Id == userId).Select(u => u.AuthorSignature).FirstOrDefault().ToString();
                if (authorSignature == null)
                {
                    throw new Exception("AuthorSignature is not found.");
                }
                var infoSheet = new InfoSheet(infoSheetCreateDto, authorSignature, userId);
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

        #region UPDATE

        public async Task<InfoSheet> UpdateInfoSheetAsync(InfoSheetUpdateDto infoSheetUpdateDto)
        {
            try
            {
                if (infoSheetUpdateDto.Designation == null && infoSheetUpdateDto.Reference == null && infoSheetUpdateDto.BarCode == null && infoSheetUpdateDto.WikiArticle == null && infoSheetUpdateDto.AuthorSignature == null)
                    throw new Exception("No changes needed.");

                var infoSheet = await context.InfoSheets.FirstAsync(i => i.Id == infoSheetUpdateDto.InfoSheetId);

                if (infoSheetUpdateDto.Designation != null)
                    infoSheet.Designation = infoSheetUpdateDto.Designation;

                if (infoSheetUpdateDto.Reference != null)
                    infoSheet.Reference = infoSheetUpdateDto.Reference;

                if (infoSheetUpdateDto.BarCode != null)
                    infoSheet.BarCode = infoSheetUpdateDto.BarCode;

                if (infoSheetUpdateDto.WikiArticle != null)
                    infoSheet.WikiArticle = infoSheetUpdateDto.WikiArticle;

                if (infoSheetUpdateDto.AuthorSignature != null)
                    infoSheet.AuthorSignature = infoSheetUpdateDto.AuthorSignature;

                infoSheet.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();

                return infoSheet;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the information sheet. {ex.Message}", ex);
            }
        }

        #endregion

        #region DELETE

        public async Task<string> DeleteInfoSheetAsync(int infoSheetId)
        {
            try
            {
                var infoSheet = await context.InfoSheets.FirstAsync(i => i.Id == infoSheetId);

                context.InfoSheets.Remove(infoSheet);

                await context.SaveChangesAsync();

                return infoSheet.Designation;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the information sheet. {ex.Message}", ex);
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

        public async Task<bool> IsCurrentUserTheOwnerOfInfoSheetAsync(UserAuthDto userAuthDto, int infoSheetId)
        {
            try
            {
                if (await context.InfoSheets.AnyAsync(i => i.UserId == userAuthDto.Id.Value && i.Id == infoSheetId))
                    return true;
                throw new Exception("The user does not own this information sheet.");
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while searching for the owner of the information sheet.");
            }
        }

        #endregion
    }
}
