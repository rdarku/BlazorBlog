using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBlog.Data;

namespace BlazorBlog.Models
{
    public class CreateLike
    {
        [Required]
        [Display(Name = "Liked")]
        public Post LikedPost { get; set; }  //Comment Texts from user for reply comment

        [Required]
        [Display(Name = "User Liker")]
        public User Liker { get; set; }      //user that is liking the post
    }
}

