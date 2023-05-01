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


        #region UTILS

        public async Task<int> AutoIndice(int roomId)
        {
            var furnitureIndicelist = await context.Furnitures.
                Where(r => r.RoomId == roomId).
                Select(r => r.Indice).Order().ToListAsync();

            for (int i = 0; i < furnitureIndicelist.Count; i++)
            {
                if (i == 0 && furnitureIndicelist[i] > 1)
                    return 1;

                if (i == furnitureIndicelist.Count - 1 || furnitureIndicelist[i + 1] - furnitureIndicelist[i] > 1)
                    return furnitureIndicelist[i] + 1;
            }

            throw new Exception("An error occurred during the AutoIndice process.");
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
            // If not null => Check indice is free. Else If null => update the indice.
            if (indiceOrDefault != null)
                await CheckIndiceIsFreeAsync(indiceOrDefault.Value, roomId);
            else // If null => update the indice
                indiceOrDefault = await AutoIndice(roomId);
            if (indiceOrDefault.Value == 0)
            {
                throw new Exception("AutoIndiceFail");
            }
            return indiceOrDefault.Value;
        }



        #endregion



    }
}
