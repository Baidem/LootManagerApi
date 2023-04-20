using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities;
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

        public async Task<HouseDto> CreateHouseAsync(HouseCreateDto houseCreateDto, int UserId)
        {
            try
            {
                House house = new House(houseCreateDto, UserId);

                await context.Houses.AddAsync(house);

                await context.SaveChangesAsync();

                return new HouseDto(house);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the House : {ex.Message}");
            }
        }

        public async Task<HouseDto> CreateTheDefaultHouseAsync(int userId)
        {
            try
            {
                var houseCreateDto = new HouseCreateDto
                {
                    Name = "My house",
                    Indice = 1
                };

                return await CreateHouseAsync(houseCreateDto, userId);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while creating the default House : {ex.Message}");
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

        public async Task<bool> ThisIndexIsFreeAsync(int indice, int userId)
        {
            var houseIndicelist = await context.Houses.Where(h => h.UserId == userId).Select(h => h.Indice).OrderBy(i => i).ToListAsync();

            int left = 0;
            int right = houseIndicelist.Count - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (houseIndicelist[middle] == indice)
                {
                    throw new Exception("This indice is not free.");
                }

                if (houseIndicelist[middle] < indice)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return true;
        }

        #endregion
    }
}
