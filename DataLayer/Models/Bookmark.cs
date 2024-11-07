using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    [Table("bookmarks")]
    public class Bookmark
    {
        [Key]
        [Column("bookmark_id")]
        public int BookmarkId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("item_type")]
        public char ItemType { get; set; }

        [Column("item_id")]
        public string ItemId { get; set; }

        [Column("annotation")]
        public string? Annotation { get; set; }
    }
}
