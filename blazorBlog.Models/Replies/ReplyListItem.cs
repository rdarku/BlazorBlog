using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Replies
{
    public class ReplyListItem
    {
        public int ReplyId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }

        [Display(Name ="Date of Reply")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
