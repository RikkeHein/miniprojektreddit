using System;
namespace miniprojektreddit.Model
{
    public class Comment
    {
       
        public Comment(string text, User user, DateTime date, int threadId)
        {
            this.Text = text;
            this.User = user;
            this.Date = date;
            this.ThreadId = threadId;   
        }

        public Comment()
        {

        }



        public long CommentId { get; set; }
        public string Text { get; set; }
        public User? User { get; set; }
        public DateTime Date { get; set; }
        public int? Upvote { get; set; }
        public int? Downvote { get; set; }

        public long ThreadId { get; set; }  
    }
}

