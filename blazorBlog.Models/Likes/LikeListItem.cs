namespace BlazorBlog.Models.Likes
{
    public class LikeListItem
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Liker { get; set; }
    }
}
