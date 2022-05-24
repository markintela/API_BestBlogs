using ModelViewShared.ModelView.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelViewShared.ModelView.Post
{
    public class PostCommentsView 
    {

        public Guid Id { get; set; }
        public IEnumerable<CommentView> Comments { get; set; }
    }
}
