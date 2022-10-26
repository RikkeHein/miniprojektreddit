using System;
namespace miniprojektreddit.Model
{
    public class Thread
    {

        public Thread(string title, User user, string text, DateTime date, int votes = 0)
        {
            this.Title = title;
            this.User = user;
            this.Text = text;
            this.Date = date;
            this.Votes = votes;
        }

        public Thread()
        {

        }

        public long ThreadId { get; set; }
        public string Title { get; set; }
        public User? User { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Votes { get; set; }
    }
}

