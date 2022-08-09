using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudMyFavoriteApp.Data
{
    [Table("games")]
    public class GameEntry
    {
        [Required]
        [Column("Id")]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("GameStudioId")]
        public long GameStudioId { get; set; }
    }
}
