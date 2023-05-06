using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities.logistics;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class FurnitureRepository : IFurnitureRepository
    {
        #region DECLARATION

        LootManagerContext context;
        ILogger<FurnitureRepository> logger;

        #endregion

        #region CONSTRUCTOR

        public FurnitureRepository(LootManagerContext context, ILogger<FurnitureRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        #endregion

        #region CREATE

        public async Task<FurnitureDto> CreateFurnitureByDtoAsync(FurnitureCreateDto furnitureCreateDto, LocationDto locationDto)
        {
            try
            {
                var furniture = new Furniture(furnitureCreateDto, locationDto);

                await context.Furnitures.AddAsync(furniture);

                await context.SaveChangesAsync();

                return new FurnitureDto(furniture);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the Furniture : {ex.Message}");
            }
        }

        #endregion

        #region READ

        public async Task<FurnitureDto> GetFurnitureDtoByIdAsync(int furnitureId)
        {
            return await context.Furnitures.Where(f => f.Id == furnitureId).Select(f => new FurnitureDto(f)).FirstAsync();
        }

        public async Task<List<FurnitureDto>> GetListOfFurnitureDtoByUserIdAsync(int userId, int numberOfElements)
        {
            var furnitureDtoList = await context.Furnitures
                .Where(f => f.UserId == userId)
                .Select(f => new FurnitureDto(f))
                .Take(numberOfElements)
                .ToListAsync();

            if (furnitureDtoList.Any())
                return furnitureDtoList;

            throw new Exception($"You have zero furnitures in your collection actually.");
        }
        public async Task<List<FurnitureDto>> GetListOfFurnitureDtoByRoomIdAsync(int roomId, int numberOfElements)
        {
            var furnitureDtoList = await context.Furnitures
                .Where(f => f.RoomId == roomId)
                .Select(f => new FurnitureDto(f))
                .Take(numberOfElements)
                .ToListAsync();

            if (furnitureDtoList.Any())
                return furnitureDtoList;

            throw new Exception($"You have zero positions in your collection actually.");
        }


        #endregion

        #region UTILS

        public async Task<int> AutoIndiceFurniture_FirstPlaceFinded(int roomId)
        {
            try
            {
                var maxIndice = await context.Furnitures
                    .Where(f => f.RoomId == roomId)
                    .Select(f => f.Indice)
                    .OrderByDescending(f => f)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);

                return maxIndice > 0 ? maxIndice + 1 : 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred during the furniture AutoIndice process. {ex.Message}", ex);
            }
        }

        public async Task<bool> CheckIndiceIsFreeAsync(int indice, int roomId)
        {
            if (await context.Furnitures.AnyAsync(f => f.RoomId == roomId && f.Indice == indice))
                throw new Exception("This indice is not free.");

            return true;
        }

        public async Task<bool> CheckTheOwnerOfTheFurnitureAsync(int userId, int furnitureId)
        {
            if (await context.Furnitures.AnyAsync(f => f.UserId == userId && f.Id == furnitureId))
                return true;

            throw new Exception("This user cannot access this furniture.");
        }

        public async Task<int> CheckIndiceFreeOrUpdateDefaultIndice(int? indiceOrDefault, int roomId)
        {
            try
            {
                // If not null => Check indice is free. Else If null => update the indice.
                if (indiceOrDefault != null)
                    await CheckIndiceIsFreeAsync(indiceOrDefault.Value, roomId);
                else // If null => update the indice
                    indiceOrDefault = await AutoIndiceFurniture_FirstPlaceFinded(roomId);

                if (indiceOrDefault.Value == 0)
                {
                    throw new Exception("AutoIndiceFail");
                }

                return indiceOrDefault.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Indice error. : {ex.Message}", ex);
            }
        }

        #endregion
    }
}
