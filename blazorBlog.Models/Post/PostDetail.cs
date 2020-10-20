using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Post
{
    public class PostDetail
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

        [Display(Name = "Post Date")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name ="Posted By")]
        public string Username { get; set; }
    }
}
