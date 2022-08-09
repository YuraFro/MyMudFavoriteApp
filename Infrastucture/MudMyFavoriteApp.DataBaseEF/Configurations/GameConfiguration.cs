using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudMyFavoriteApp.Data;

namespace MudMyFavoriteApp.DataBaseEF.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<GameEntry>
    {
        public void Configure(EntityTypeBuilder<GameEntry> builder)
        {
            builder.HasKey(item => item.Id);
            builder.HasIndex(item => item.Id).IsUnique();
        }
    }
}
