using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Repository.Context;

namespace Repository.Repository
{
  

    public class PostRepository : IPostRepository
    {
        private readonly DataContext _dataContext;
        public PostRepository (DataContext context)
        {
            _dataContext = context;
        }
        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<Post> GetAsync(Guid id)
        {
            return await _dataContext.Posts.FindAsync(id);
        }

        public async Task<Post> CreateAsync(Post post)
        {
            await _dataContext.Posts.AddAsync(post);
            await _dataContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post> UpdateAsync(Post post)
        {
            var postUpdated = await _dataContext.Posts.FindAsync(post.Id);

            if (postUpdated == null)
            {
                return null;
            }

            _dataContext.Entry(postUpdated).CurrentValues.SetValues(post);

            _dataContext.Posts.Update(postUpdated);
            await _dataContext.SaveChangesAsync();
            return postUpdated;
        }

        public async Task DeleteAsync(Guid id)
        {
            var postToDelete = await _dataContext.Posts.FindAsync(id);
            _dataContext.Posts.Remove(postToDelete);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Comment>> GetCommentByPostIdAsync(Guid postId)
        {
            var comments = await _dataContext.Comments.Include(c => c.Post).Where(c => c.Post.Id == postId).ToListAsync();
            return comments;
        }
    }
}