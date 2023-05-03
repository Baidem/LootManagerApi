using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities.logistics;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class ShelfRepository : IShelfRepository
    {
        #region DECLARATION

        LootManagerContext context;
        ILogger<ShelfRepository> logger;
        ILocationRepository locationRepository;
        IPositionRepository positionRepository;

        #endregion

        #region CONSTRUCTOR

        public ShelfRepository(LootManagerContext context, ILogger<ShelfRepository> logger, ILocationRepository locationRepository, IPositionRepository positionRepository)
        {
            this.context = context;
            this.logger = logger;
            this.locationRepository = locationRepository;
            this.positionRepository = positionRepository;
        }

        #endregion

        #region CREATE

        public async Task<ShelfDto> CreateShelfByDtoAsync(ShelfCreateDto shelfCreateDto, LocationDto locationDto)
        {
            try
            {
                var shelf = new Shelf(shelfCreateDto, locationDto);

                await context.Shelves.AddAsync(shelf);

                await context.SaveChangesAsync();

                return new ShelfDto(shelf);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the Shelf : {ex.Message}");
            }
        }

        public async Task<FurnitureDto> GenerateShelvesAsync(FurnitureDto furnitureDto, int numberOfShelves, int numberOfPositionsPerShelf)
        {
            Furniture furniture = await context.Furnitures.
                FirstAsync(f => f.Id == furnitureDto.Id);

            if (numberOfShelves > 0)
            {
                for (int i = 0; i < numberOfShelves; i++)
                {
                    LocationDto locDto_shelf = await locationRepository.
                        CreateLocationByUserIdAsync(furnitureDto.UserId);

                    var sheCreDto = new ShelfCreateDto { FurnitureId = furnitureDto.Id, IndiceOrDefault = i + 1 };

                    var shelfDto = await CreateShelfByDtoAsync(sheCreDto, locDto_shelf);

                    if (numberOfPositionsPerShelf > 0)
                    {
                        for (int j = 0; j < numberOfPositionsPerShelf; j++)
                        {
                            LocationDto locDto_pos = await locationRepository.
                                CreateLocationByUserIdAsync(shelfDto.UserId);

                            var posCreDto = new PositionCreateDto { ShelfId = shelfDto.Id, IndiceOrDefault = i + 1 };

                            await positionRepository.CreatePositionByDtoAsync(posCreDto, locDto_pos);
                        }
                    }
                }

            }

            await context.SaveChangesAsync();

            return furnitureDto;

            throw new NotImplementedException();
        }

        #endregion



        #region UTILS

        public async Task<int> AutoIndiceShelf_LastAddOne(int furnitureId)
        {
            try
            {
                var maxIndice = await context.Shelves // version corrigée
                            .Where(s => s.FurnitureId == furnitureId)
                            .Select(s => s.Indice)
                            .MaxAsync()
                            .ConfigureAwait(false);

                return maxIndice + 1;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during the AutoIndice process.", ex);
            }
        }

        public async Task<bool> CheckIndiceIsFreeAsync(int indice, int furnitureId)
        {
            if (await context.Shelves.AnyAsync(s => s.FurnitureId == furnitureId && s.Indice == indice))
                throw new Exception("This indice is not free.");

            return true;
        }

        public async Task<bool> CheckTheOwnerOfTheShelfAsync(int userId, int shelfId)
        {
            if (await context.Shelves.AnyAsync(f => f.UserId == userId && f.Id == shelfId))
                return true;

            throw new Exception("This user cannot access this shelf.");
        }

        public async Task<ShelfCreateDto> CheckIndiceFreeOrUpdateDefaultIndice(ShelfCreateDto shelfCreateDto)
        {
            try
            {
                // If not null => Check indice is free. Else If null => update the indice.
                if (shelfCreateDto.IndiceOrDefault != null)
                    await CheckIndiceIsFreeAsync(shelfCreateDto.IndiceOrDefault.Value, shelfCreateDto.FurnitureId);
                else // If null => update the indice
                    shelfCreateDto.IndiceOrDefault = await AutoIndiceShelf_LastAddOne(shelfCreateDto.FurnitureId);

                if (shelfCreateDto.IndiceOrDefault.Value == 0)
                    throw new Exception("AutoIndiceFail");

                return shelfCreateDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Indice error. ", ex);
            }
        }


        #endregion

    }
}
