using System;
namespace miniprojektreddit.Model
{
    public class Thread
    {
        public Thread(string title, User user, string text, DateTime date)
        {
            this.Title = title;
            this.User = user;
            this.Text = text;
            this.Date = date;
        }

        public Thread(string title, User user, string text, DateTime date, List<Comment> comments)
        {
            this.Title = title;
            this.User = user;
            this.Text = text;
            this.Date = date;
            this.Comments = comments;
        }


        public Thread()
        {

        }

        public long ThreadId { get; set; }
        public string Title { get; set; }
        public User? User { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int? Upvote { get; set; }
        public int? Downvote { get; set; }
        public List<Comment>? Comments { get; set; } = new List<Comment>();
    }
}

