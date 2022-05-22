using AutoMapper;
using Management.Manager;
using Manager.Interfaces.Repository;
using Model.Domain;
using ModelViewShared.ModelView.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Implementation
{
    public class PostManager : IPostManager
    {

        private readonly IPostRepository _postRepository;
        public readonly IMapper _mapper;

        public PostManager(IPostRepository postRepository, IMapper mapper)
        {            
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post> GetAsync(Guid id)
        {
            return await _postRepository.GetAsync(id);
        }

        public async Task<Post> CreateAsync(Post post)
        {
            return await _postRepository.CreateAsync(post);   
        }

        public async Task<Post> UpdateAsync(Post post)
        {
            return await _postRepository.UpdateAsync(post);
        }
        public async Task<IEnumerable<Comment>> GetCommentByPostIdAsync(Guid postId)
        {
            var post =   await _postRepository.GetCommentByPostIdAsync(postId);
            return post;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _postRepository.DeleteAsync(id);
        }
    }
}
