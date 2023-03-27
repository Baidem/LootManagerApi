using LootManagerApi.Dto;
using LootManagerApi.Entities;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class ElementRepository : IElementRepository
    {
        #region DECLARATION
        LootManagerContext context;
        ILogger<ElementRepository> logger;

        #endregion
        #region CONSTRUCTOR
        public ElementRepository(LootManagerContext context, ILogger<ElementRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        /// <summary>
        /// Create an user's element
        /// </summary>
        /// <param name="elementCreateDto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ElementCreateDto CreateElement(ElementCreateDto elementCreateDto, int userId)
        {
            Element element = new Element(elementCreateDto, userId);
            context.Elements.Add(element);
            context.SaveChanges();
            return elementCreateDto;
        }

        /// <summary>
        /// Get all user's elements
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<string>> GetElementsAsync(int userId)
        {
            return await context.Elements.Where(e => e.UserId == userId).Select(e => e.Name).ToListAsync();
        }

        /// <summary>
        /// Get an element by his id from a user
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Element> GetElementAsync(int elementId, int userId)
        {
            return await context.Elements.Where(e => e.UserId == userId).FirstOrDefaultAsync(e => e.Id == elementId);
        }

        public async Task<Element> UpdateElementAsync(ElementUpdateDto elementUpdateDto, int userId)
        {
            try
            {
                var elementUpdate = await context.Elements.Where(e => e.UserId == userId).FirstOrDefaultAsync(e => e.Id == elementUpdateDto.Id);
                if (elementUpdate != null)
                {
                    if (elementUpdateDto.Name != null)
                        elementUpdate.Name = elementUpdateDto.Name;
                    if (elementUpdateDto.Description != null)
                        elementUpdate.Description = elementUpdateDto.Description;
                    if (elementUpdateDto.Type != null)
                        elementUpdate.Type = elementUpdateDto.Type;
                    await context.SaveChangesAsync();
                    return elementUpdate;
                }
                else
                {
                    logger?.LogError("Update is not correct.");
                    return null;
                }
            }
            catch (Exception e)
            {
                logger?.LogError(e?.InnerException?.ToString());
                return null;
            }
        }

        /// <summary>
        /// Delete a User's element.
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Element> DeleteElementAsync(int elementId, int userId)
        {
            try
            {
                var element = await context.Elements.FirstOrDefaultAsync(e => e.Id == elementId && e.UserId == userId);
                if (element == null)
                {
                    logger?.LogError("Element don't exist.");
                    return null;
                }
                context.Elements.Remove(element);
                await context.SaveChangesAsync();
                return element;
            }
            catch (Exception e)
            {
                logger?.LogError(e?.InnerException?.ToString());
                return null;
            }
        }
        #endregion

    }
}
