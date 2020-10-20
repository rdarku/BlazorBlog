using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorBlog.Data
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public virtual Post LikedPost { get; set; }

        [ForeignKey(nameof(Like))]
        public int LikeId { get; set; }
        public virtual User Liker { get; set; }
    }
}