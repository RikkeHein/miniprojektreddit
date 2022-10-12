using System;
namespace miniprojektreddit.Model
{
    public class User
    {
        public User(string name)
        {
            this.Name = name;
        }

        public User()
        {

        }

        public long UserId { get; set; }
        public string Name { get; set; }
    }
}

