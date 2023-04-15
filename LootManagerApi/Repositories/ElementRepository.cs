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

        #endregion

        #region CREATE

        public async Task<ElementDto> CreateElementAsync(ElementCreateDto elementCreateDto, int userId)
        {
            try
            {
                Element element = new Element(elementCreateDto, userId);

                await context.Elements.AddAsync(element);

                await context.SaveChangesAsync();

                return new ElementDto(element);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the element : {ex.Message}");
            }
        }

        #endregion

        #region READ

        public async Task<List<ElementDto>> GetElementsAsync(int userId)
        {
            var elementDtos = await context.Elements.Where(e => e.UserId == userId).Select(e => new ElementDto(e)).ToListAsync();

            if (elementDtos.Any())
                return elementDtos;

            throw new Exception($"You have zero elements in your collection actually.");
        }

        public async Task<ElementDto> GetElementAsync(int elementId)
        {
            var elementDtos = await context.Elements.Where(e => e.Id == elementId).Select(e => new ElementDto(e)).FirstOrDefaultAsync();

            if (elementDtos != null)
                return elementDtos;

            throw new Exception($"Element was not found.");
        }

        #endregion

        #region ???

        /// <summary>
        /// Update an user's element
        /// </summary>
        /// <param name="elementUpdateDto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Element> UpdateElementAsync(ElementUpdateDto elementUpdateDto, int userId)
        {
            var element = await context.Elements.Where(e => e.UserId == userId).FirstOrDefaultAsync(e => e.Id == elementUpdateDto.Id);
            if (element != null)
            {
                if (elementUpdateDto.Name != null && elementUpdateDto.Description != null && elementUpdateDto.Type != null)
                {
                    element.Name = elementUpdateDto.Name;
                    element.Description = elementUpdateDto.Description;
                    element.Type = elementUpdateDto.Type;
                }
            }
            else
            {
                throw new Exception($"Error please fill all the blank spaces !");
            }
            await context.SaveChangesAsync();
            return element;

        }

        /// <summary>
        /// Delete a User's element.
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Element> DeleteElementAsync(int elementId, int userId)
        {
            var element = await context.Elements.FirstOrDefaultAsync(e => e.Id == elementId && e.UserId == userId);
            if (element == null)
            {
                throw new Exception($"Element wasnot found.");
            }
            context.Elements.Remove(element);
            await context.SaveChangesAsync();
            return element;
        }

        #endregion

        #region UTILS

        public async Task<bool> IsOwnerOfTheElementAsync(int userId, int elementId)
        {
            if (await context.Elements.AnyAsync(e => e.UserId == userId && e.Id == elementId))
                return true;

            throw new Exception("This user cannot access this element.");
        }

        #endregion

    }
}
