using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace miniprojektreddit.Model
{
	//Forbindelse til databasen.
	public class RedditContext : DbContext
	{
		public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public string DbPath { get; }

        public RedditContext(DbContextOptions<RedditContext> options)
            : base(options)
        {
            /* Den her er tom. Men ": base(options)" sikre at constructor på 
               DbContext super-klassen bliver kaldt.*/
        }
    }


}

