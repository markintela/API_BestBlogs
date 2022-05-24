using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Management.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Repository.Context;

namespace Repository.Repository
{
   

    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _dataContext;
        public CommentRepository(DataContext context)
        {
             _dataContext = context;
        }
        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _dataContext.Comments.Include(c => c.Post).ToListAsync();
        }

        public async Task<Comment> GetAsync(Guid id)
        {
            return await _dataContext.Comments.Include(c => c.Post).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await AddCommentToPost(comment);
            await _dataContext.Comments.AddAsync(comment);
            await _dataContext.SaveChangesAsync();
            return comment;
        }

        private async Task AddCommentToPost(Comment comment)
        {
            var post = new Post();
            post = await _dataContext.Posts.FindAsync(comment.Post.Id);
            comment.Post = post;
            comment.CreationDate = DateTime.Now;
        }

        public async Task<Comment> UpdateAsync(Comment comment)
        {
            var commentUpdated = await _dataContext.Comments.Include(p => p.Post).SingleOrDefaultAsync(c => c.Id == comment.Id);
            if (commentUpdated == null)
            {
                return null;
            }
            _dataContext.Entry(commentUpdated).CurrentValues.SetValues(comment);
            _dataContext.Comments.Update(commentUpdated);
            await _dataContext.SaveChangesAsync();
            return commentUpdated;
        }

        public async Task DeleteAsync(Guid id)
        {
            var commentToDelete = await _dataContext.Comments.FindAsync(id);
            _dataContext.Comments.Remove(commentToDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}