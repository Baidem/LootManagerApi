﻿using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class RoomCreateDto
    {
        [Required] public string Name { get; set; }
        [Required] public int HouseId { get; set; }
        public int? IndiceOrDefault { get; set; }
    }
}
