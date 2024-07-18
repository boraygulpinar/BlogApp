﻿namespace BlogApp.Entitiy
{
    public class User
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
