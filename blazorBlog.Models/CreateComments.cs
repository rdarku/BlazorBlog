using System.ComponentModel.DataAnnotations;

namespace blazorBlog.Models
{
    public class CreateComments
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }  //Comment Texts from user
        
        [Required]
        public int Id { get; set; }      //user ID
    }
}
