using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorBlog.Data
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(LikedPost))]
        public int PostId { get; set; }

        public virtual Post LikedPost { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser Liker { get; set; }
    }
}