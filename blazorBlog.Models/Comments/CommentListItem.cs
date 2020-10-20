namespace BlazorBlog.Models.Comments
{
    public class CommentListItem
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string CommentAuthor { get; set; } 
    }
}
