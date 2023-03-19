using LootManagerApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class LootManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Element> Elements { get; set; }

        public LootManagerContext(DbContextOptions<LootManagerContext> option) : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Default data
            // Users
            var u1 = new User { Id = 1, FullName = "test", Email = "test@test.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"), CreatedAt = DateTime.UtcNow };
            var u2 = new User { Id = 2, FullName = "Jerry Seinfeld", Email = "jerry@aol.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("userNumber1!"), CreatedAt = DateTime.UtcNow };
            var u3 = new User { Id = 3, FullName = "George Costanza", Email = "George.Costanza@aol.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("userNumber1!"), CreatedAt = DateTime.UtcNow };
            var u4 = new User { Id = 4, FullName = "Elaine Benes", Email = "Elaine.Benes@aol.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("userNumber1!"), CreatedAt = DateTime.UtcNow };
            var u5 = new User { Id = 5, FullName = "Cosmo Kramer", Email = "Cosmo.Kramer@aol.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("userNumber1!"), CreatedAt = DateTime.UtcNow };

            modelBuilder.Entity<User>().HasData(new List<User> { u1, u2, u3, u4, u5 });

            // Elements
            var e1 = new Element { Id = 1, Name = "element1", Type = "Type undefined ", Description = "Description of the element", LocationAddress = "Location undifined", UserId = 1 };
            var e2 = new Element { Id = 2, Name = "element2", Type = "Type undefined ", Description = "Description of the element", LocationAddress = "Location undifined", UserId = 2 };
            var e3 = new Element { Id = 3, Name = "element3", Type = "Type undefined ", Description = "Description of the element", LocationAddress = "Location undifined", UserId = 3 };
            var e4 = new Element { Id = 4, Name = "element4", Type = "Type undefined ", Description = "Description of the element", LocationAddress = "Location undifined", UserId = 4 };
            var e5 = new Element { Id = 5, Name = "element5", Type = "Type undefined ", Description = "Description of the element", LocationAddress = "Location undifined", UserId = 5 };

            modelBuilder.Entity<Element>().HasData(new List<Element> { e1, e2, e3, e4, e5 });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Lootmanager;Trusted_Connection=True;");
        }
    }
}