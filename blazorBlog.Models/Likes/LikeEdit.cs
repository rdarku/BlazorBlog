using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Likes
{
    public class LikeEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}
