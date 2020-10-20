using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorBlog.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid UserId { get; set; }
        public virtual User Author { get; set; }

        [ForeignKey(nameof(CommentPost))]
        public int PostId { get; set; }
        public virtual Post CommentPost { get; set; }
    }
}
