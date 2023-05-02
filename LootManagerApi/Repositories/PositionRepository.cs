using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Dto;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using LootManagerApi.Entities.logistics;

namespace LootManagerApi.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        #region DECLARATION

        LootManagerContext context;
        ILogger<PositionRepository> logger;
        ILocationRepository locationRepository;

        #endregion

        #region CONSTRUCTOR

        public PositionRepository(LootManagerContext context, ILogger<PositionRepository> logger, ILocationRepository locationRepository)
        {
            this.context = context;
            this.logger = logger;
            this.locationRepository = locationRepository;
        }

        #endregion

        #region CREATE

        public async Task<PositionDto> CreatePositionByDtoAsync(PositionCreateDto positionCreateDto, LocationDto locationDto)
        {
            try
            {
                var position = new Position(positionCreateDto, locationDto);

                await context.Positions.AddAsync(position);

                await context.SaveChangesAsync();

                return new PositionDto(position);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the Position : {ex.Message}");
            }
        }

        public async Task<ShelfDto> GeneratePositionsAsync(ShelfDto shelfDto)
        {
            try
            {
                Shelf shelf = await context.Shelves.
                    FirstAsync(s => s.Id == shelfDto.Id);

                int N = shelfDto.PositionsCount.Value;

                if (N > 0)
                {
                    for (int i = 0; i < N; i++)
                    {
                        LocationDto locDto = await locationRepository.
                            CreateLocationByUserIdAsync(shelfDto.UserId);

                        var posCreDto = new PositionCreateDto { ShelfId = shelfDto.Id, IndiceOrDefault = i + 1 };

                        await CreatePositionByDtoAsync(posCreDto, locDto);
                    }
                }

                shelf.NumberOfPositions = await context.Positions.
                    CountAsync(p => p.ShelfId == shelfDto.Id);

                await context.SaveChangesAsync();

                return new ShelfDto(shelf);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while generating the Positions : {ex.Message}");
            }
        }


        #endregion

        #region UTILS

        public async Task<int> AutoIndicePosition_LastAddOne(int shelfId)
        {
            try
            {
                var maxIndice = await context.Positions // version corrigée
                            .Where(p => p.ShelfId == shelfId)
                            .Select(p => p.Indice)
                            .MaxAsync()
                            .ConfigureAwait(false);

                return maxIndice + 1;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during the AutoIndice process.", ex);
            }
        }

        public async Task<bool> CheckIndiceIsFreeAsync(int indice, int shelfId)
        {
            if (await context.Positions.AnyAsync(s => s.ShelfId == shelfId && s.Indice == indice))
                throw new Exception("This indice is not free.");

            return true;
        }

        public async Task<PositionCreateDto> CheckIndiceFreeOrUpdateDefaultIndice(PositionCreateDto positionCreateDto)
        {
            // If not null => Check indice is free. Else If null => update the indice.
            if (positionCreateDto.IndiceOrDefault != null)
                await CheckIndiceIsFreeAsync(positionCreateDto.IndiceOrDefault.Value, positionCreateDto.ShelfId);
            else // If null => update the indice
                positionCreateDto.IndiceOrDefault = await AutoIndicePosition_LastAddOne(positionCreateDto.ShelfId);
            if (positionCreateDto.IndiceOrDefault.Value == 0)
            {
                throw new Exception("AutoIndiceFail");
            }
            return positionCreateDto;
        }


        #endregion
    }
}
