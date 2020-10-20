using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Likes
{
    public class LikeCreate
    {
        [Required]
        public int PostId { get; set; }
    }
}
