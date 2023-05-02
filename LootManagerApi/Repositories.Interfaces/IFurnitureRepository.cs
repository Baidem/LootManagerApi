using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IFurnitureRepository
    {
        // CREATE
        Task<FurnitureDto> CreateFurnitureByDtoAsync(FurnitureCreateDto furnitureCreateDto, LocationDto location);

        //// READ
        //Task<List<FurnitureDto>> GetListOfFurnitureDtoByUserIdAsync(int userId);
        //Task<FurnitureDto> GetFurnitureDtoByFurnitureIdAsync(int furnitureId);

        //// UPDATE
        //Task<FurnitureDto> UpdateFurnitureByDtoAsync(FurnitureUpdateDto furnitureUpdateDto);

        //// DELETE
        //Task<FurnitureDto> DeleteFurnitureAsync(int furnitureId);

        // UTILS
        Task<int> AutoIndiceFirstPlaceFinded(int roomId);
        Task<bool> CheckIndiceIsFreeAsync(int indice, int roomId);

        Task<bool> CheckTheOwnerOfTheFurnitureAsync(int userId, int furnitureId);
        Task<int> CheckIndiceFreeOrUpdateDefaultIndice(int? IndiceOrDefault, int roomId);
    }
}
