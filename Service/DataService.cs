using Microsoft.EntityFrameworkCore;
using miniprojektreddit.Model;
using Thread = miniprojektreddit.Model.Thread;

namespace miniprojektreddit.Service
{
    public class DataService
    {
        private RedditContext db { get; }
        public DataService(RedditContext db)
        {
            this.db = db;
        }

        //Seeder noget nyt data i databasen hvis der ikke findes noget i forvejen.
        public void SeedData()
        {
            Random random = new Random();

            // Seed users
            //----------------------------------------------------------------------------------------------
            User u1 = db.Users.FirstOrDefault();
            if (u1 == null)
            {
                u1 = new User { Name = "Rikke" };
                db.Users.Add(u1);
            }

            User u2 = db.Users.FirstOrDefault();
            if (u2 == null)
            {
                u2 = new User { Name = "Kerstine" };
                db.Users.Add(u2);
            }

            User u3 = db.Users.FirstOrDefault();
            if (u3 == null)
            {
                u3 = new User { Name = "Cecilie" };
                db.Users.Add(u3);
            }

            // Seed threads
            //----------------------------------------------------------------------------------------------
            Thread t1 = db.Threads.FirstOrDefault();
            if (t1 == null)
            {
                t1 = new Thread("Git", u2, "Learn how to Git", new DateTime(2022, 10, 11, 10, 40, 20), random.Next(-10, 200));
                db.Threads.Add(t1);
            }

            Thread t2 = db.Threads.FirstOrDefault();
            if (t2 == null)
            {
                t2 = new Thread("Thread vs. Fred", u1, "Give me your best questions to this subject", new DateTime(2022, 10, 11, 10, 40, 20), random.Next(-10, 200));
                db.Threads.Add(t2);
            }

            Thread t3 = db.Threads.FirstOrDefault();
            if (t3 == null)
            {
                t3 = new Thread("How to clean your bucket", u3, "You take some and soap and cry", new DateTime(2022, 10, 11, 10, 40, 20), random.Next(-10, 200));
                db.Threads.Add(t3);
            }

            Thread t4 = db.Threads.FirstOrDefault();
            if (t4 == null)
            {
                t4 = new Thread("Blazor and API", u2, "It doesn't work", new DateTime(2022, 10, 26, 10, 40, 20), random.Next(-10, 200));
                db.Threads.Add(t4);
            }

            Thread t5 = db.Threads.FirstOrDefault();
            if (t5 == null)
            {
                t5 = new Thread("Learn how to use blazor", u1, "Blazor is a good feature, to make a website", new DateTime(2022, 10, 26, 13, 40, 20), random.Next(-10, 200));
                db.Threads.Add(t5);
            }

            Thread t6 = db.Threads.FirstOrDefault();
            if (t6 == null)
            {
                t6 = new Thread(".NET", u3, "It's er very very good thing", new DateTime(2022, 10, 26, 12, 40, 20), random.Next(-10, 200));
                db.Threads.Add(t6);
            }

            Thread t7 = db.Threads.FirstOrDefault();
            if (t7 == null)
            {
                t7 = new Thread("Threads", u2, "A way to learn new things", new DateTime(2022, 10, 26, 10, 40, 20), random.Next(-10, 200));
                db.Threads.Add(t7);
            }

            Thread t8 = db.Threads.FirstOrDefault();
            if (t8 == null)
            {
                t8 = new Thread("Comments", u1, "A good way to give your opinion", new DateTime(2022, 10, 26, 13, 40, 20), random.Next(-10, 200));
                db.Threads.Add(t8);
            }

            Thread t9 = db.Threads.FirstOrDefault();
            if (t9 == null)
            {
                t9 = new Thread("Users", u3, "All of you", new DateTime(2022, 10, 26, 12, 40, 20), random.Next(-10, 200));
                db.Threads.Add(t9);
            }

            Thread t10 = db.Threads.FirstOrDefault();
            if (t10 == null)
            {
                t10 = new Thread("School", u3, "It's very tricky", new DateTime(2022, 10, 26, 12, 40, 20), random.Next(-10, 200));
                db.Threads.Add(t10);
            }

            // Seed comments
            //----------------------------------------------------------------------------------------------
            Comment c1 = db.Comments.FirstOrDefault();
            if (c1 == null)
            {
                c1 = new Comment("Git is very tricky, git me a bucket!", u1, new DateTime(2022, 10, 12, 10, 52, 20), t1, random.Next(-10, 200));
                db.Comments.Add(c1);
            }

            Comment c2 = db.Comments.FirstOrDefault();
            if (c2 == null)
            {
                c2 = new Comment("Is thread the same as Fred????", u2, new DateTime(2022, 10, 12, 10, 52, 21), t2, random.Next(-10, 200));
                db.Comments.Add(c2);
            }

            Comment c3 = db.Comments.FirstOrDefault();
            if (c3 == null)
            {
                c3 = new Comment("Who is Fred???", u3, new DateTime(2022, 10, 12, 10, 52, 22), t2, random.Next(-10, 200));
                db.Comments.Add(c3);
            }

            Comment c4 = db.Comments.FirstOrDefault();
            if (c4 == null)
            {
                c4 = new Comment("Give me a bucket, please!", u1, new DateTime(2022, 10, 12, 10, 52, 20), t4, random.Next(-10, 200));
                db.Comments.Add(c4);
            }

            Comment c5 = db.Comments.FirstOrDefault();
            if (c5 == null)
            {
                c5 = new Comment("HELP! Bad exampel", u2, new DateTime(2022, 10, 12, 10, 52, 21), t5, random.Next(-10, 200));
                db.Comments.Add(c5);
            }

            Comment c6 = db.Comments.FirstOrDefault();
            if (c6 == null)
            {
                c6 = new Comment("Are you missing the core??", u2, new DateTime(2022, 10, 12, 10, 52, 22), t6, random.Next(-10, 200));
                db.Comments.Add(c6);
            }

            Comment c7 = db.Comments.FirstOrDefault();
            if (c7 == null)
            {
                c7 = new Comment("Can you give me more examples, please?", u3, new DateTime(2022, 10, 12, 10, 52, 22), t7, random.Next(-10, 200));
                db.Comments.Add(c7);
            }

            Comment c8 = db.Comments.FirstOrDefault();
            if (c8 == null)
            {
                c8 = new Comment("I like making comments - please upvote me!", u3, new DateTime(2022, 10, 12, 10, 52, 20), t8, random.Next(-10, 200));
                db.Comments.Add(c8);
            }

            Comment c9 = db.Comments.FirstOrDefault();
            if (c9 == null)
            {
                c9 = new Comment("Yaaay I'm one of the useres!!", u2, new DateTime(2022, 10, 12, 10, 52, 21), t9, random.Next(-10, 200));
                db.Comments.Add(c9);
            }

            Comment c10 = db.Comments.FirstOrDefault();
            if (c10 == null)
            {
                c10 = new Comment("I just loooove schoool", u1, new DateTime(2022, 10, 12, 10, 52, 22), t10, random.Next(-10, 200));
                db.Comments.Add(c10);
            }

            db.SaveChanges();
        }

        //Henter alle threads i en liste til forsiden hvor forfatter også vises
        public List<Thread> GetThreads()
        {
            return db.Threads.Include(t => t.User).ToList();
        }

        //Henter en bestemt tråd via id
        public Thread GetThread(int id)
        {
            return db.Threads.Include(t => t.User).ToList().FirstOrDefault(t => t.ThreadId == id);
        }

        //Henter en bestemt tråds kommentar 
        public List<Comment> GetComments(int id)
        {
            return db.Comments.Include(c => c.Thread).ThenInclude(c => c.User).Where(c => c.Thread.ThreadId == id).ToList();
        }

        //Henter alle users i en liste
        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        //Henter en bestemt user via id
        public User GetUser(int id)
        {
            return db.Users.FirstOrDefault(u => u.UserId == id);
        }

        //creater en ny thread og tilføjer den til databasen
        public string CreateThread(string title, int userId, string text, DateTime date)
        {
            User user = db.Users.FirstOrDefault(u => u.UserId == userId);
            db.Threads.Add(new Thread { Title = title, User = user, Text = text, Date = date });
            db.SaveChanges();
            return "Thread created";
        }

        //creater en ny Comment og tilføjer den til databasen
        public string CreateComment(string text, int userId, DateTime date, int threadId)
        {
            User user = db.Users.FirstOrDefault(u => u.UserId == userId);
            Thread thread = db.Threads.FirstOrDefault(t => t.ThreadId == threadId);
            db.Comments.Add(new Comment { Text = text, User = user, Date = date, Thread = thread });
            db.SaveChanges();
            return "Comment created";
        }

        // Tilføjer en stemme til en post
        public string AddVoteThread(int threadId, bool vote)
        {
            if (vote == true)
            {
                Thread thread = db.Threads.Where(x => x.ThreadId == threadId).First();

                thread.Votes++;
            }
            else if (vote == false)
            {
                Thread thread = db.Threads.Where(x => x.ThreadId == threadId).First();

                thread.Votes--;
            }

            db.SaveChanges();

            return "Vote added";
        }

        // Tilføjer en stemme til en kommentar
        public string AddVoteComment(int commentId, bool vote)
        {
            if (vote == true)
            {
                Comment comment = db.Comments.Where(x => x.CommentId == commentId).First();

                comment.Votes++;
            }
            else if (vote == false)
            {
                Comment comment = db.Comments.Where(x => x.CommentId == commentId).First();

                comment.Votes--;
            }

            db.SaveChanges();

            return "Vote added";
        }
    }
}