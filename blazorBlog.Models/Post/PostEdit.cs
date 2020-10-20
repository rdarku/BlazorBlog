﻿using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Post
{
    public class PostEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
    }
}
