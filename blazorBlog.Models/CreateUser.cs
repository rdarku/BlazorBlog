using System;
using System.ComponentModel.DataAnnotations;

namespace blazorBlog.Models
{
    public class CreateUser
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Name of User")]
        public string Name { get; set; }        //name of User

        [Required]
        [Display(Name = "User ID")]
        public Guid Id { get; set; }             //user ID

        [Required]
        [Display(Name = "User Email")]
        public string Email { get; set; }      //user Email
    }
}
