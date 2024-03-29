﻿using LootManagerApi.Dto;
using LootManagerApi.Entities.logistics;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Entities
{
    public class Element
    {
        #region PROPERTIES

        public int Id { get; set; }
        public string Name { get; set; } // The name given by the user
        public string? Description { get; set; } // The description given by the user
        public string? Type { get; set; } // The object type
        public string? Grade { get; set; } // The state of preservation of the object
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #endregion

        #region NAVIGATION PROPERTIES (4)

        // One User To Many Element?
        public int UserId { get; set; }
        public User User { get; set; }

        // One Location? To Many Element?
        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        // Many Element? To Many Images?
        public List<Image>? Images { get; set; }

        // One InfoSheet? To Many Element?
        public int? InfoSheetId { get; set; }
        public InfoSheet? InfoSheet { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Element()
        {
        }

        public Element(ElementCreateDto elementCreateDto, int userId)
        {
            Name = elementCreateDto.Name;
            Description = elementCreateDto.Description;
            Type = elementCreateDto.Type;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = null;
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