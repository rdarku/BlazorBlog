using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Replies
{
    public class ReplyDetail
    {
        public Guid? ReplyId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }

        public string Reply { get; set; }

        [Display(Name = "Date of Reply")]
        public DateTimeOffset CreatedUtc { get; set; }
        public string ReplyAuthor { get; set; }
        public string CommentAuthor { get; set; }
    }
}
