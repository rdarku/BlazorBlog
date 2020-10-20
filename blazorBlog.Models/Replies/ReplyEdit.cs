using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Replies
{
    public class ReplyEdit
    {
        [Required]
        public int ReplyId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Reply Comment")]
        public string Text { get; set; }  //Comment Texts from user for reply comment

        [Required]
        [Display(Name = "User ID")]
        public int CommentId { get; set; }      //user ID

        public int PostID { get; set; }
    }
}
