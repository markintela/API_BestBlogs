using System;

namespace Model.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Post Post { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
    }
}