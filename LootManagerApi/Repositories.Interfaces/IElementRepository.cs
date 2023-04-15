﻿using LootManagerApi.Dto;
using LootManagerApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IElementRepository
    {
        Task<ElementDto> CreateElementAsync(ElementCreateDto elementCreateDto, int userId);
        Task<List<string>> GetElementsAsync(int userId);
        Task<Element> GetElementAsync(int elementId, int userId);
        Task<Element> UpdateElementAsync(ElementUpdateDto elementUpdateDto, int userId);
        Task<Element> DeleteElementAsync(int elementId, int userId);
    }
}
