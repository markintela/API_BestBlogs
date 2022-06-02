using Model.Domain;
using ModelViewShared.ModelView.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Manager
{
    public interface ICommentManager
    {
        Task<IEnumerable<CommentView>> GetAllAsync();

        Task<Comment> GetAsync(Guid id);


        Task<Comment> CreateAsync(NewCommment comment);


        Task<Comment> UpdateAsync(UpdateComment comment);


        Task DeleteAsync(Guid id);


        Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId);
    }
}
