using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Interfaces.Repository
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllAsync();

        Task<Comment> GetAsync(Guid id);


        Task<Comment> CreateAsync(Comment comment);


        Task<Comment> UpdateAsync(Comment comment);


        Task DeleteAsync(Guid id);


        Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId);
      
    }
}
