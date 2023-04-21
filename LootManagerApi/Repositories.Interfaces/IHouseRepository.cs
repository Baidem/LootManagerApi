using LootManagerApi.Dto;
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

        // UPDATE
        Task<HouseDto> UpdateHouseAsync(HouseUpdateDto houseUpdateDto);

        // DELETE
        Task<HouseDto> DeleteHouseAsync(int houseId);

        // UTILS
        Task<int> AutoIndice(int userId);
        Task<bool> ThisIndexIsFreeAsync(int indice, int userId);

        Task<bool> IsOwnerOfTheHouseAsync(int userId, int houseId);
        // TODO La fonction IsOwnerOfTheHouseAsync rend cette fonction obsolète.
        Task<bool> IsHouseExistAsync(int houseId);
    }
}
