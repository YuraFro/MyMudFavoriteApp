using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudMyFavoriteApp.Data;

namespace MudMyFavoriteApp.DataBaseEF.Configurations
{
    public class GameStudioConfiguration : IEntityTypeConfiguration<GameStudioEntry>
    {
        public void Configure(EntityTypeBuilder<GameStudioEntry> builder)
        {
            builder.HasKey(item => item.Id);
            builder.HasIndex(item => item.Id).IsUnique();
        }
    }
}
