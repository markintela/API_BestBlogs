using System;
using System.Collections.Generic;

namespace Model.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}