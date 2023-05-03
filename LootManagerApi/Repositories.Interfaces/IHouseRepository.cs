using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IHouseRepository
    {
        // CREATE
        Task<HouseDto> CreateHouseByDtoAsync(HouseCreateDto houseCreateDto, LocationDto locationDto);

        // READ
        Task<List<HouseDto>> GetListOfHouseDtoByUserIdAsync(int userId);
        Task<HouseDto> GetHouseDtoByHouseIdAsync(int houseId);

        // UPDATE
        Task<HouseDto> UpdateHouseByDtoAsync(HouseUpdateDto houseUpdateDto);

        // DELETE
        Task<HouseDto> DeleteHouseAsync(int houseId);

        // UTILS
        Task<int> AutoIndiceHouse_LastAddOne(int userId);
        Task<bool> CheckIndiceIsFreeAsync(int indice, int userId);

        Task<bool> CheckTheOwnerOfTheHouseAsync(int userId, int houseId);
        Task<int> CheckIndiceFreeOrUpdateDefaultIndice(int? IndiceOrDefault, int userId);

    }
}
