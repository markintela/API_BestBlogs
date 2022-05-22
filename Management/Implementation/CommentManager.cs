using AutoMapper;
using Management.Interfaces.Repository;
using Management.Manager;
using Model.Domain;
using ModelViewShared.ModelView.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Implementation
{
    public class CommentManager : ICommentManager
    {

        private readonly ICommentRepository _commentRepository;
        public readonly IMapper _mapper;
        public CommentManager(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _commentRepository.GetAllAsync();
        }

        public async Task<Comment> GetAsync(Guid id)
        {
            return await _commentRepository.GetAsync(id);
        }

        public async Task<Comment> CreateAsync(NewCommment newComment)
        {
            var comment = _mapper.Map<Comment>(newComment);
            return await  _commentRepository.CreateAsync(comment);
        }

        public async Task<Comment> UpdateAsync(UpdateComment updateComment)
        {
            var comment = _mapper.Map<Comment>(updateComment);
            return await _commentRepository.UpdateAsync(comment);
        }

        public async Task DeleteAsync(Guid id)
        {
             await _commentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}
