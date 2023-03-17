﻿using LootManagerApi.Entities;
using System.Security.Claims;

namespace LootManagerApi.Dto
{
    public class UserAuthentifiedDto
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }

        public UserAuthentifiedDto()
        {
        }

        public UserAuthentifiedDto(ClaimsIdentity identity)
        {
            Id = Int32.Parse(identity?.FindFirst(ClaimTypes.NameIdentifier).Value);
            FullName = identity?.FindFirst(ClaimTypes.Name).Value;
            Email = identity?.FindFirst(ClaimTypes.Email).Value;
        }

    }
}