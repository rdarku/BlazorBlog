using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Data
{
    public class Reply : Comment
    {
        [Key]
        public int ReplyId { get; set; }
        public Comment ReplyComment { get; set; } 
    }
}
