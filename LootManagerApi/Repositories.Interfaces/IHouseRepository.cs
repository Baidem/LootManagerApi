﻿using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IHouseRepository
    {
        // CREATE
        Task<HouseDto> CreateHouseAsync(HouseCreateDto houseCreateDto, int UserId);
        Task<HouseDto> CreateTheDefaultHouseAsync(int userId);

        // READ
        Task<List<HouseDto>> GetHousesAsync(int userId);
        Task<HouseDto> GetHouseAsync(int houseId);

        // UTILS
        Task<int> AutoIndice(int userId);
        Task<bool> ThisIndexIsFreeAsync(int indice, int userId);

        Task<bool> IsOwnerOfTheHouseAsync(int userId, int houseId);
        Task<bool> IsHouseExistAsync(int houseId);


    }
}