using LootManagerApi.Dto;
using LootManagerApi.Entities;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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

        #region UPDATE

        /// <summary>
        /// Asynchronous method of updating an Element by an ElementUpdateDto.
        /// Id required to find the element to be updated.
        /// Only non-null data will be modified.
        /// </summary>
        /// <param name="elementUpdateDto"></param>
        /// <returns>ElementDto</returns>
        /// <exception cref="Exception"></exception>
        public async Task<ElementDto> UpdateElementAsync(ElementUpdateDto elementUpdateDto)
        {
            try
            {
                if (elementUpdateDto.Name == null && elementUpdateDto.Description == null && elementUpdateDto.Type == null)
                    throw new Exception("No changes needed.");

                Element element = await context.Elements.FirstAsync(e => e.Id == elementUpdateDto.Id);

                if (elementUpdateDto.Name != null)
                    element.Name = elementUpdateDto.Name;

                if (elementUpdateDto.Description != null)
                    element.Description = elementUpdateDto.Description;

                if (elementUpdateDto.Type != null)
                    element.Type = elementUpdateDto.Type;

                element.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();

                return new ElementDto(element);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the element. {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Asynchronous method of updating the element location.
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="elementId"></param>
        /// <returns>ElementDto</returns>
        /// <exception cref="Exception"></exception>
        public async Task<ElementDto> AddLocationToElementAsync(int locationId, int elementId)
        {
            try
            {
                Element element = await context.Elements.FirstAsync(e => e.Id == elementId);

                element.LocationId = locationId;

                element.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();

                return new ElementDto(element);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the element. {ex.Message}", ex);
            }
        }

        #endregion

        #region DELETE

        public async Task<ElementDto> DeleteElementAsync(int elementId)
        {
            try
            {
                var element = await context.Elements.FirstAsync(e => e.Id == elementId);

                context.Elements.Remove(element);

                await context.SaveChangesAsync();

                return new ElementDto(element);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the element. {ex.Message}", ex);
            }
        }

        #endregion

        #region UTILS

        public async Task<bool> IsOwnerOfTheElementAsync(int userId, int elementId)
        {
            if (await context.Elements.AnyAsync(e => e.UserId == userId && e.Id == elementId))
                return true;

            throw new Exception("This user cannot access this element.");
        }

        public async Task<bool> IsElementExistAsync(int elementId)
        {
            if (await context.Elements.AnyAsync(e => e.Id == elementId))
                return true;

            throw new Exception("This element does not exist in the database.");
        }

        #endregion
    }
}
