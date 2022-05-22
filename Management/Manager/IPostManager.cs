using Model.Domain;
using ModelViewShared.ModelView.Comment;
using ModelViewShared.ModelView.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Manager
{
    public interface IPostManager
    {
        Task<IEnumerable<Post>> GetAllAsync();


        Task<Post> GetAsync(Guid id);

        Task<IEnumerable<CommentView>> GetCommentByPostIdAsync(Guid postId);
       
        Task<Post> CreateAsync(NewPost post);


        Task<Post> UpdateAsync(Post post);

        Task DeleteAsync(Guid id);
    }
}
