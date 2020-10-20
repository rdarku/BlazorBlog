﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorBlog.Data
{
    public class Reply : Comment
    {
        [Key]
        public int ReplyId { get; set; }

        public int CommentId { get; set; }

        [ForeignKey(nameof(CommentId))]
        public Comment ReplyComment { get; set; } 
    }
}
