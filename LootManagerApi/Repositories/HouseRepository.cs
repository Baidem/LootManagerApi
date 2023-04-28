using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities.logistics;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        #region DECLARATION

        LootManagerContext context;
        ILogger<UserRepository> logger;

        #endregion

        #region CONSTRUCTOR

        public HouseRepository(LootManagerContext context, ILogger<UserRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        #endregion

        #region CREATE

        public async Task<HouseDto> CreateHouseByDtoAsync(HouseCreateDto houseCreateDto, int UserId)
        {
            try
            {
                return new HouseDto(await CreateHouseAsync(new House(houseCreateDto, UserId)));
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the House : {ex.Message}");
            }
        }

        private async Task<House> CreateHouseAsync(House house)
        {
            await context.Houses.AddAsync(house);

            await context.SaveChangesAsync();

            return house;
        }

        #endregion

        #region READ

        public async Task<List<HouseDto>> GetListOfHouseDtoByUserIdAsync(int userId)
        {
            var houseDtoList = await context.Houses.Where(e => e.UserId == userId).Select(e => new HouseDto(e)).ToListAsync();

            if (houseDtoList.Any())
                return houseDtoList;

            throw new Exception($"You have zero houses in your collection actually.");
        }

        public async Task<HouseDto> GetHouseDtoByHouseIdAsync(int houseId)
        {
            var houseDtos = await context.Houses.Where(e => e.Id == houseId).Select(e => new HouseDto(e)).FirstOrDefaultAsync();

            if (houseDtos != null)
                return houseDtos;

            throw new Exception($"House was not found.");
        }

        #endregion

        #region UPDATE

        /// <summary>
        ///Updating an House by an HouseUpdateDto. 
        /// </summary>
        /// <param name="houseUpdateDto"></param>
        /// <returns>HouseDto</returns>
        /// <exception cref="Exception"></exception>
        public async Task<HouseDto> UpdateHouseByDtoAsync(HouseUpdateDto houseUpdateDto)
        {
            try
            {
                House house = await context.Houses.FirstAsync(h => h.Id == houseUpdateDto.Id);

                house.Name = houseUpdateDto.Name;

                house.Indice = houseUpdateDto.Indice;

                house.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();

                return new HouseDto(house);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the house. {ex.Message}", ex);
            }
        }

        #endregion

        #region DELETE

        public async Task<HouseDto> DeleteHouseAsync(int houseId)
        {
            try
            {
                var house = await context.Houses.FirstAsync(e => e.Id == houseId);

                context.Houses.Remove(house);

                await context.SaveChangesAsync();

                return new HouseDto(house);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the house. {ex.Message}", ex);
            }
        }

        #endregion

        #region UTILS

        public async Task<int> AutoIndice(int userId)
        {
            var houseIndicelist = await context.Houses.Where(h => h.UserId == userId).Select(h => h.Indice).ToListAsync();

            houseIndicelist.Sort();
            for (int i = 0; i < houseIndicelist.Count; i++)
            {
                if (i == 0 && houseIndicelist[i] > 1)
                    return 1;

                if (i == houseIndicelist.Count - 1 || houseIndicelist[i + 1] - houseIndicelist[i] > 1)
                    return houseIndicelist[i] + 1;
            }

            throw new Exception("An error occurred during the AutoIndice process.");
        }

        public async Task<bool> CheckIndiceIsFreeAsync(int indice, int userId)
        {
            if (await context.Houses.AnyAsync(h => h.UserId == userId && h.Indice == indice))
                throw new Exception("This indice is not free.");

            return true;
        }

        public async Task<bool> CheckTheOwnerOfTheHouseAsync(int userId, int houseId)
        {
            if (await context.Houses.AnyAsync(e => e.UserId == userId && e.Id == houseId))
                return true;

            throw new Exception("This user cannot access this house.");
        }

        #endregion
    }
}
