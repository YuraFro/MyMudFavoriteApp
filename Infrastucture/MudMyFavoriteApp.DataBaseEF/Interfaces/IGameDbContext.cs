using Microsoft.EntityFrameworkCore;
using MudMyFavoriteApp.Data;

namespace MudMyFavoriteApp.DataBaseEF
{
    public interface IGameDbContext
    {
        DbSet<GameEntry> Games { get; set; }
        DbSet<GameStudioEntry> GameStudios { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
