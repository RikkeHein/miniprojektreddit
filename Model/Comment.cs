using System;
namespace miniprojektreddit.Model
{
    public class Comment
    {
        public Comment(string text, User author, DateTime date)
        {
            this.Text = text;
            this.Author = author;
            this.Date = date;
        }

        public Comment()
        {

        }

        public long CommentId { get; set; }
        public string Text { get; set; }
        public User? Author { get; set; }
        public DateTime Date { get; set; }
        public int? Upvote { get; set; }
        public int? Downvote { get; set; }

    }
}

