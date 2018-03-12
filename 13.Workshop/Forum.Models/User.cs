using System.Collections.Generic;

namespace Forum.Models
{
    public class User
    {
        public User(int id, string username, string password, ICollection<int> psotIds)
        {
            Id = id;
            Username = username;
            Password = password;
            PostIds = new List<int>(psotIds);
        }

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
            PostIds = new List<int>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<int> PostIds { get; set; }
    }
}
