using LootManagerApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class LootManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public LootManagerContext(DbContextOptions<LootManagerContext> option) : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Default data
            // Users
            var u1 = new User { Id = 1, FullName = "test", Email = "test", PasswordHash = BCrypt.Net.BCrypt.HashPassword("test") };
            var u2 = new User { Id = 2, FullName = "Jerry Seinfeld", Email = "jerry@aol.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("userNumber1!") };
            var u3 = new User { Id = 3, FullName = "George Costanza", Email = "George.Costanza@aol.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("userNumber1!") };
            var u4 = new User { Id = 4, FullName = "Elaine Benes", Email = "Elaine.Benes@aol.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("userNumber1!") };
            var u5 = new User { Id = 5, FullName = "Cosmo Kramer", Email = "Cosmo.Kramer@aol.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("userNumber1!") };

            modelBuilder.Entity<User>().HasData(new List<User> { u1, u2, u3, u4, u5 });
           
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Lootmanager;Trusted_Connection=True;");
        }

    }

    
}
