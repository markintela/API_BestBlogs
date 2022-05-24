using AutoMapper;
using Management.Interfaces.Repository;
using Management.Manager;
using Manager.Interfaces.Repository;
using Model.Domain;
using ModelViewShared.ModelView.Comment;
using ModelViewShared.ModelView.Post;
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
        private readonly ICommentRepository _commentRepository;
        public readonly IMapper _mapper;

        public PostManager(IPostRepository postRepository, ICommentRepository commentRepository, IMapper mapper)
        {            
            _postRepository = postRepository;
            _commentRepository =  commentRepository;
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

        public async Task<Post> CreateAsync(NewPost newPost)
        {
            var post = _mapper.Map<Post>(newPost);
            return await _postRepository.CreateAsync(post);   
        }

        public async Task<Post> UpdateAsync(Post post)
        {
            return await _postRepository.UpdateAsync(post);
        }
        public async Task<PostCommentsView> GetCommentByPostIdAsync(Guid postId)
        {
            var post = await _postRepository.GetAsync(postId);
            //var comments = await _commentRepository.GetAllAsync();
            //post.Comments = comments.Where(x => x.Post.Id == postId);
            return _mapper.Map<PostCommentsView>(post);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _postRepository.DeleteAsync(id);
        }
    }
}
