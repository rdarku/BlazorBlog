namespace BlazorBlog.Models.Likes
{
    public class LikeListItem
    {
        public int Id { get; set; }

        public int PostID { get; set; }

        public string Liker { get; set; }
    }
}
