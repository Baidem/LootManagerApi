using LootManagerApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class LootManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Location> Locations { get; set; }
        //public DbSet<ElementLocation> ElementsLocations { get; set; }

        public LootManagerContext(DbContextOptions<LootManagerContext> option) : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Default datas
            #region Data Users
            var u1 = new User
            {
                Id = 1,
                FullName = "admin",
                Email = "admin@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.Admin
            };
            var u2 = new User
            {
                Id = 2,
                FullName = "user",
                Email = "user@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.User
            };
            var u3 = new User
            {
                Id = 3,
                FullName = "contributor",
                Email = "contributor@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.Contributor
            };
            var u4 = new User
            {
                Id = 4,
                FullName = "user4",
                Email = "user4@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.User
            };
            var u5 = new User
            {
                Id = 5,
                FullName = "user5",
                Email = "user5",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.User
            };

            modelBuilder.Entity<User>().HasData(new List<User> { u1, u2, u3, u4, u5 });
            #endregion

            #region Data Elements
            var e1 = new Element { Id = 1, Name = "figurine1", Type = "Figurine ", Description = "Description of the element", UserId = 1 };
            var e2 = new Element { Id = 2, Name = "figurine2", Type = "Figurine ", Description = "Description of the element", UserId = 2 };
            var e3 = new Element { Id = 3, Name = "figurine3", Type = "Figurine ", Description = "Description of the element", UserId = 3 };
            var e4 = new Element { Id = 4, Name = "figurine4", Type = "Figurine ", Description = "Description of the element", UserId = 4 };
            var e5 = new Element { Id = 5, Name = "figurine5", Type = "Figurine ", Description = "Description of the element", UserId = 5 };

            var e6 = new Element { Id = 6, Name = "manga1", Type = "Manga", Description = "Description of the element", UserId = 1 };
            var e7 = new Element { Id = 7, Name = "manga2", Type = "Manga", Description = "Description of the element", UserId = 2 };
            var e8 = new Element { Id = 8, Name = "manga3", Type = "Manga", Description = "Description of the element", UserId = 3 };
            var e9 = new Element { Id = 9, Name = "manga4", Type = "Manga", Description = "Description of the element", UserId = 4 };
            var e10 = new Element { Id = 10, Name = "manga5", Type = "Manga", Description = "Description of the element", UserId = 5 };

            var e11 = new Element { Id = 11, Name = "comic1", Type = "Comic", Description = "Description of the element", UserId = 1 };
            var e12 = new Element { Id = 12, Name = "comic2", Type = "Comic", Description = "Description of the element", UserId = 2 };
            var e13 = new Element { Id = 13, Name = "comic3", Type = "Comic", Description = "Description of the element", UserId = 3 };
            var e14 = new Element { Id = 14, Name = "comic4", Type = "Comic", Description = "Description of the element", UserId = 4 };
            var e15 = new Element { Id = 15, Name = "comic5", Type = "Comic", Description = "Description of the element", UserId = 5 };


            modelBuilder.Entity<Element>().HasData(new List<Element> { e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12, e13, e14, e15 });
            #endregion

            #region Data Locations
            var l1 = new Location { Id = 1, House = "House1", Room = "Room1", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 1 };
            var l2 = new Location { Id = 2, House = "House1", Room = "Room2", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 1 };
            var l3 = new Location { Id = 3, House = "House1", Room = "Room3", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 1 };

            var l4 = new Location { Id = 4, House = "House2", Room = "Room1", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 2 };
            var l5 = new Location { Id = 5, House = "House2", Room = "Room2", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 2 };
            var l6 = new Location { Id = 6, House = "House2", Room = "Room3", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 2 };

            var l7 = new Location { Id = 7, House = "House3", Room = "Room1", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 3 };
            var l8 = new Location { Id = 8, House = "House3", Room = "Room2", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 3 };
            var l9 = new Location { Id = 9, House = "House3", Room = "Room3", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 3 };

            var l10 = new Location { Id = 10, House = "House4", Room = "Room1", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 4 };
            var l11 = new Location { Id = 11, House = "House4", Room = "Room2", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 4 };
            var l12 = new Location { Id = 12, House = "House4", Room = "Room3", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 4 };

            var l13 = new Location { Id = 13, House = "House5", Room = "Room1", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 5 };
            var l14 = new Location { Id = 14, House = "House5", Room = "Room2", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 5 };
            var l15 = new Location { Id = 15, House = "House5", Room = "Room3", Furniture = "Furniture1", Shelf = "First Shelf", Position = 1, UserId = 5 };

            modelBuilder.Entity<Location>().HasData(new List<Location> { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15 });
            #endregion
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Lootmanager;Trusted_Connection=True;");
        }
    }
}