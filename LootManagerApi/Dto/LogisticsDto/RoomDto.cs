﻿using LootManagerApi.Entities;
using LootManagerApi.Entities.logistics;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class RoomDto
    {
        #region PROPERTIES

        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int HouseId { get; set; }

        #endregion

        #region CONSTRUCTOR

        public RoomDto()
        {
        }

        public RoomDto(Room room)
        {
            Id = room.Id;
            Name = room.Name;
            Indice = room.Indice;
            HouseId = room.HouseId;
            CreatedAt = room.CreatedAt;
            UpdatedAt = room.UpdatedAt;
        }

        #endregion

        #region METHODS

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name}: {prop.GetValue(this)}");
            }
            return sb.ToString();
        }

        #endregion
    }
}