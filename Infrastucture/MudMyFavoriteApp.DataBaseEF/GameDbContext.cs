using Microsoft.EntityFrameworkCore;
using MudMyFavoriteApp.Data;
using MudMyFavoriteApp.DataBaseEF.Configurations;

namespace MudMyFavoriteApp.DataBaseEF
{
    public class GameDbContext : DbContext, IGameDbContext
    {
        public DbSet<GameEntry> Games { get; set; }

        public DbSet<GameStudioEntry> GameStudios { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GameStudioEntry>().HasData(
                new GameStudioEntry
                {
                    Name = "RockStar",
                    Id = 1,
                    County = "USA",
                    Culture = "EN"
                },
                new GameStudioEntry
                {
                    Name = "GSG",
                    Id = 2,
                    County = "RUS",
                    Culture = "RU"
                });

            builder.Entity<GameEntry>().HasData(
                new GameEntry
                {
                    Name = "GTA 5",
                    Description = "DWQDQWDQ",
                    Id = 1,
                    GameStudioId = 0
                },
                new GameEntry
                {
                    Name = "Red Dead Red",
                    Description = "123",
                    Id = 2,
                    GameStudioId = 0
                },
                new GameEntry
                {
                    Name = "Stalker",
                    Description = "tre",
                    Id = 3,
                    GameStudioId = 1
                });

            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new GameStudioConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
