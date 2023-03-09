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
            var u1 = new User { Id = 1, FullName = "Jerry Seinfeld", Email = "jerry@aol.com", Password = "pwd" };
            var u2 = new User { Id = 2, FullName = "George Costanza", Email = "George.Costanza@aol.com", Password = "george" };
            var u3 = new User { Id = 3, FullName = "Elaine Benes", Email = "Elaine.Benes@aol.com", Password = "jerry" };
            var u4 = new User { Id = 4, FullName = "Cosmo Kramer", Email = "Cosmo.Kramer@aol.com", Password = "qzerty" };

            modelBuilder.Entity<User>().HasData(new List<User> { u1, u2, u3, u4 });
           
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Lootmanager;Trusted_Connection=True;");
        }

    }

    
}
