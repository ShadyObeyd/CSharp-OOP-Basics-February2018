using Forum.Models;
using System.Collections.Generic;

namespace Forum.Data
{
    public class ForumData
    {
        public ForumData()
        {
            Users = DataMapper.LoadUsers();
            Categories = DataMapper.LoadCateogries();
            Posts = DataMapper.LoadPosts();
            Replies = DataMapper.LoadReplies();
        }

        public List<Category> Categories { get; set; }
        public List<User> Users { get; set; }
        public List<Post> Posts { get; set; }
        public List<Reply> Replies { get; set; }

        public void SaveChanges()
        {
            DataMapper.SaveUsers(Users);
            DataMapper.SavePosts(Posts);
            DataMapper.SaveReplies(Replies);
            DataMapper.SaveCategories(Categories);
        }
    }
}
