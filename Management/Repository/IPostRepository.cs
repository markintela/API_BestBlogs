using Model.Domain;
using ModelViewShared.ModelView.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Interfaces.Repository
{
    public interface IPostRepository
    {

        Task<IEnumerable<Post>> GetAllAsync();


        Task<Post> GetAsync(Guid id);

        Task<IEnumerable<Comment>> GetCommentByPostIdAsync(Guid postId);

        Task<Post> CreateAsync(Post post);


        Task<Post> UpdateAsync(Post post);

        Task DeleteAsync(Guid id);

        bool ValidationExistInDatabase(Guid post);
    }
}
