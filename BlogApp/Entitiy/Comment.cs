namespace BlogApp.Entitiy
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string? CommentText { get; set; }
        public DateTime PublishedOn { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; } = null!;
        public int UserID { get; set; }
        public User User { get; set; } = null!;
    }
}
