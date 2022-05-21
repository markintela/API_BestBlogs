using Model.Domain;
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


        Task<Post> CreateAsync(Post post);


        Task<Post> UpdateAsync(Post post);

        Task DeleteAsync(Guid id);
    }
}
