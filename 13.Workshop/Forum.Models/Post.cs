using System.Collections.Generic;

namespace Forum.Models
{
    public class Post
    {
        public Post(int id, string title, string content, int categoryId, int authorId, ICollection<int> replyIds)
        {
            Id = id;
            Title = title;
            Content = content;
            CategoryId = categoryId;
            AuthorId = authorId;
            ReplyIds = new List<int>(replyIds);
        }

        public Post(int id, string title, string content, int categoryId, int authorId)
        {
            Id = id;
            Title = title;
            Content = content;
            CategoryId = categoryId;
            AuthorId = authorId;
            ReplyIds = new List<int>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public ICollection<int> ReplyIds { get; set; }
    }
}
