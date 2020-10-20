﻿using BlazorBlog.Data;
using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Likes
{
    public class LikeCreate
    {
        [Required]
        [Display(Name = "Liked")]
        public Post LikedPost { get; set; }  //Comment Texts from user for reply comment

        [Required]
        [Display(Name = "User Liker")]
        public User Liker { get; set; }      //user that is liking the post
    }
}
