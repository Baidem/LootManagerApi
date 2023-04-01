﻿using LootManagerApi.Dto;

namespace LootManagerApi.Utils
{
    public static class UtilsRole
    {
        public static bool CheckOnlyAdmin(UserAuthDto userAuthDto)
        {
            if (!userAuthDto.Role.Equals("Admin"))
            {
                throw new Exception("This function is only available to users with the administrator role.");
            }
            return true;
        }
    }
}
