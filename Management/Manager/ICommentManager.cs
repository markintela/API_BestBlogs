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
        Task<IEnumerable<Comment>> GetAllAsync();

        Task<Comment> GetAsync(Guid id);


        Task<Comment> CreateAsync(NewCommment comment);


        Task<Comment> UpdateAsync(Comment comment);


        Task DeleteAsync(Guid id);


        Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId);
    }
}
