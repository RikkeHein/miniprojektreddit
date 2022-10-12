using System;
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
            User u4 = new User("Peter");
            db.Users.Add(u4);

            /*
            // Seed users
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

            // Seed comments
            Comment c1 = db.Comments.FirstOrDefault();
            if(c1 == null)
            {
                c1 = new Comment("Git is very tricky, git me a bucket!", u1, new DateTime(2022, 10, 12, 10, 52, 20));
                db.Comments.Add(c1);
            }

            Comment c2 = db.Comments.FirstOrDefault();
            if (c2 == null)
            {
                c2 = new Comment("Is thread the same as Fred????", u2, new DateTime(2022, 10, 12, 10, 52, 21));
                db.Comments.Add(c2);
            }

            Comment c3 = db.Comments.FirstOrDefault();
            if (c3 == null)
            {
                c3 = new Comment("Who is Fred???", u3, new DateTime(2022, 10, 12, 10, 52, 22));
                db.Comments.Add(c3);
            }

            // Seed threads
            Thread t1 = db.Threads.FirstOrDefault();
            if(t1 == null)
            {
                t1 = new Thread("Git", u2, "Learn how to Git", new DateTime(2022, 10, 11, 10, 40, 20), new List<Comment>() { c1 });
                db.Threads.Add(t1);
            }

            Thread t2 = db.Threads.FirstOrDefault();
            if (t2 == null)
            {
                t2 = new Thread("Thread vs. Fred", u1, "Give me your best questions to this subject", new DateTime(2022, 10, 11, 10, 40, 20), new List<Comment>() { c2, c3 });
                db.Threads.Add(t2);
            }

            Thread t3 = db.Threads.FirstOrDefault();
            if (t3 == null)
            {
                t3 = new Thread("How to clean your bucket", u3, "You take some and soap and cry", new DateTime(2022, 10, 11, 10, 40, 20));
                db.Threads.Add(t3);
            }
            */

            db.SaveChanges();
        }

        //Henter alle threads i en liste til forsiden hvor forfatter også vises
        public List<Thread> GetThreads()
        {
            return db.Threads.Include(t => t.Author).ToList();
        }

        //Henter en bestemt tråd via id og viser tilhørende kommentar og forfatter 
        public Thread GetThreadWithComments(int id)
        {
            return db.Threads.Include(t => t.Comments).ThenInclude(t => t.Author).FirstOrDefault(t => t.ThreadId == id); 
        }

    }
}

