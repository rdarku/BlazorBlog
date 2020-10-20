using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Posts
{
    public class PostListItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name ="Post Date")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
