using LootManagerApi.Entities;
using LootManagerApi.Entities.logistics;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class LootManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<InfoSheet> InfoSheets { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Position> Positions { get; set; }

        public LootManagerContext(DbContextOptions<LootManagerContext> option) : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Default data
            #region USERS DATA

            var admin = new User
            {
                Id = 1,
                FullName = "admin",
                Email = "admin@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.Admin
            };
            var user = new User
            {
                Id = 2,
                FullName = "user",
                Email = "user@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.User
            };
            var cont = new User
            {
                Id = 3,
                FullName = "contributor",
                Email = "contributor@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.Contributor
            };
            modelBuilder.Entity<User>().HasData(new List<User> { admin, user, cont });
            #endregion

            #region HOUSES DATA

            var h1 = new House { Id = 1, Name = "Admin House", Indice = 1, UserId = 1 };
            var h2 = new House { Id = 2, Name = "User House", Indice = 1, UserId = 2 };
            var h3 = new House { Id = 3, Name = "Cont House", Indice = 1, UserId = 3 };

            modelBuilder.Entity<House>().HasData(new List<House> { h1, h2, h3 });

            #endregion

            #region ROOMS DATA

            var r1 = new Room { Id = 1, Name = "Admin Room", Indice = 1, HouseId = 1 };
            var r2 = new Room { Id = 2, Name = "User Room", Indice = 1, HouseId = 2 };
            var r3 = new Room { Id = 3, Name = "Cont Room", Indice = 1, HouseId = 3 };

            modelBuilder.Entity<Room>().HasData(new List<Room> { r1, r2, r3 });

            #endregion

            #region FURNITURES DATA

            var f1 = new Furniture { Id = 1, Name = "Admin Furniture", Indice = 1, NumberOfShelves = 1, RoomId = 1 };
            var f2 = new Furniture { Id = 2, Name = "User Furniture", Indice = 1, NumberOfShelves = 1, RoomId = 2 };
            var f3 = new Furniture { Id = 3, Name = "Cont Furniture", Indice = 1, NumberOfShelves = 1, RoomId = 3 };

            modelBuilder.Entity<Furniture>().HasData(new List<Furniture> { f1, f2, f3 });

            #endregion

            #region SHELVES DATA

            var s1 = new Shelf { Id = 1, Name = "Admin Shelf", Indice = 1, NumberOfPositions = 1, FurnitureId = 1 };
            var s2 = new Shelf { Id = 2, Name = "User Shelf", Indice = 1, NumberOfPositions = 1, FurnitureId = 2 };
            var s3 = new Shelf { Id = 3, Name = "Cont Shelf", Indice = 1, NumberOfPositions = 1, FurnitureId = 3 };

            modelBuilder.Entity<Shelf>().HasData(new List<Shelf> { s1, s2, s3 });

            #endregion

            #region POSITIONS DATA

            var p1 = new Position { Id = 1, Name = "Admin Position", Indice = 1, ShelfId = 1 };
            var p2 = new Position { Id = 2, Name = "User Position", Indice = 1, ShelfId = 2 };
            var p3 = new Position { Id = 3, Name = "Cont Position", Indice = 1, ShelfId = 3 };

            modelBuilder.Entity<Position>().HasData(new List<Position> { p1, p2, p3 });

            #endregion

            #region LOCATION DATA

            var lh1 = new Location { Id = 1, HouseId = 1 };
            var lh2 = new Location { Id = 2, HouseId = 2 };
            var lh3 = new Location { Id = 3, HouseId = 3 };

            modelBuilder.Entity<Location>().HasData(new List<Location> { lh1, lh2, lh3 });

            var lr1 = new Location { Id = 4, HouseId = 1, RoomId = 1 };
            var lr2 = new Location { Id = 5, HouseId = 2, RoomId = 2 };
            var lr3 = new Location { Id = 6, HouseId = 3, RoomId = 3 };

            modelBuilder.Entity<Location>().HasData(new List<Location> { lr1, lr2, lr3 });

            var lf1 = new Location { Id = 7, HouseId = 1, RoomId = 1, FurnitureId = 1 };
            var lf2 = new Location { Id = 8, HouseId = 2, RoomId = 2, FurnitureId = 2 };
            var lf3 = new Location { Id = 9, HouseId = 3, RoomId = 3, FurnitureId = 3 };

            modelBuilder.Entity<Location>().HasData(new List<Location> { lf1, lf2, lf3 });

            var ls1 = new Location { Id = 10, HouseId = 1, RoomId = 1, FurnitureId = 1, ShelfId = 1 };
            var ls2 = new Location { Id = 11, HouseId = 2, RoomId = 2, FurnitureId = 2, ShelfId = 2 };
            var ls3 = new Location { Id = 12, HouseId = 3, RoomId = 3, FurnitureId = 3, ShelfId = 3 };

            modelBuilder.Entity<Location>().HasData(new List<Location> { ls1, ls2, ls3 });

            var lp1 = new Location { Id = 13, HouseId = 1, RoomId = 1, FurnitureId = 1, ShelfId = 1, PositionId = 1 };
            var lp2 = new Location { Id = 14, HouseId = 2, RoomId = 2, FurnitureId = 2, ShelfId = 2, PositionId = 2 };
            var lp3 = new Location { Id = 15, HouseId = 3, RoomId = 3, FurnitureId = 3, ShelfId = 3, PositionId = 3 };

            modelBuilder.Entity<Location>().HasData(new List<Location> { lp1, lp2, lp3 });

            #endregion

            #region INFOSHEETS DATA

            var is1 = new InfoSheet
            {
                Id = 1,
                Designation = "Figurine",
                Reference = "Fig-ref_01",
                BarCode = "3 037920 02133 1",
                WikiArticle = "Small statue depicting a popular culture character.",
                AuthorSignature = "The Contributor",
                CreatedAt = DateTime.UtcNow,
                UserId = 3
            };

            var is2 = new InfoSheet
            {
                Id = 2,
                Designation = "Manga",
                Reference = "Man-ref_01",
                BarCode = "3 037920 02133 1",
                WikiArticle = "Japanese comic book.",
                AuthorSignature = "The Contributor",
                CreatedAt = DateTime.UtcNow,
                UserId = 3
            };

            var is3 = new InfoSheet
            {
                Id = 3,
                Designation = "Comic",
                Reference = "Com-ref_01",
                BarCode = "3 037920 02133 1",
                WikiArticle = "Illustrated story in a book or magazine format, often featuring superheroes or humor.",
                AuthorSignature = "The Contributor",
                CreatedAt = DateTime.UtcNow,
                UserId = 3
            };

            modelBuilder.Entity<InfoSheet>().HasData(new List<InfoSheet> { is1, is2, is3 });

            #endregion

            #region ELEMENTS DATA

            // Fig
            var e1 = new Element
            {
                Id = 1,
                Name = "Admin Fig",
                Description = "Description of the element",
                Type = "Figurine",
                Grade = "An excellent condition.",
                CreatedAt = DateTime.UtcNow,
                UserId = 1,
                LocationId = 1,
                InfoSheetId = 1
            };
            var e2 = new Element
            {
                Id = 2,
                Name = "User Fig",
                Description = "Description of the element",
                Type = "Figurine",
                Grade = "An excellent condition.",
                CreatedAt = DateTime.UtcNow,
                UserId = 2,
                LocationId = 2,
                InfoSheetId = 1
            };
            var e3 = new Element
            {
                Id = 3,
                Name = "Cont Fig",
                Description = "Description of the element",
                Type = "Figurine",
                Grade = "An excellent condition.",
                CreatedAt = DateTime.UtcNow,
                UserId = 3,
                LocationId = 3,
                InfoSheetId = 1
            };

            // Manga
            var e4 = new Element
            {
                Id = 4,
                Name = "Admin Manga",
                Description = "Description of the element",
                Type = "Manga",
                Grade = "An excellent condition.",
                CreatedAt = DateTime.UtcNow,
                UserId = 1,
                LocationId = 1,
                InfoSheetId = 2
            };
            var e5 = new Element
            {
                Id = 5,
                Name = "User Manga",
                Description = "Description of the element",
                Type = "Manga",
                Grade = "An excellent condition.",
                CreatedAt = DateTime.UtcNow,
                UserId = 2,
                LocationId = 2,
                InfoSheetId = 2
            };
            var e6 = new Element
            {
                Id = 6,
                Name = "Cont Manga3",
                Description = "Description of the element",
                Type = "Manga",
                Grade = "An excellent condition.",
                CreatedAt = DateTime.UtcNow,
                UserId = 3,
                LocationId = 3,
                InfoSheetId = 2
            };

            // Comic
            var e7 = new Element
            {
                Id = 7,
                Name = "Admin Comic",
                Description = "Description of the element",
                Type = "Comic",
                Grade = "An excellent condition.",
                CreatedAt = DateTime.UtcNow,
                UserId = 1,
                LocationId = 1,
                InfoSheetId = 3
            };
            var e8 = new Element
            {
                Id = 8,
                Name = "User Comic",
                Description = "Description of the element",
                Type = "Comic",
                Grade = "An excellent condition.",
                CreatedAt = DateTime.UtcNow,
                UserId = 2,
                LocationId = 2,
                InfoSheetId = 3
            };
            var e9 = new Element
            {
                Id = 9,
                Name = "Cont Comic",
                Description = "Description of the element",
                Type = "Comic",
                Grade = "An excellent condition.",
                CreatedAt = DateTime.UtcNow,
                UserId = 3,
                LocationId = 3,
                InfoSheetId = 3
            };


            modelBuilder.Entity<Element>().HasData(new List<Element> { e1, e2, e3, e4, e5, e6, e7, e8, e9 });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}