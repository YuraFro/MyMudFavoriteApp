using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudMyFavoriteApp.Data
{
    [Table("game_studios")]
    public class GameStudioEntry
    {
        [Required]
        [Column("Id")]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("County")]
        public string County { get; set; }

        [Column("Culture")]
        public string Culture { get; set; }
    }
}
