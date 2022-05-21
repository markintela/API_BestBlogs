using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Management.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Domain;
using ModelViewShared.ModelView.Comment;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentManager _commentManager;

        public CommentController(ILogger<CommentController> logger, ICommentManager commentManager)
        {
            _logger = logger;
            _commentManager = commentManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentManager.GetAllAsync();
            if (comments  == null)
            {
                throw new KeyNotFoundException("Comment list is empty.");
            }           
            return Ok(comments);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var comment = await _commentManager.GetAsync(id);
            if (comment == null)
            {
                throw new KeyNotFoundException("Comment not found.");
            }    
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewCommment newComment)
        {
            var coommentToCreate = await _commentManager.CreateAsync(newComment);
            if (coommentToCreate == null)
            {
                throw new ApplicationException("Comment not created.");

            }
            return CreatedAtAction(nameof(Get), new { id = coommentToCreate.Id }, coommentToCreate);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Comment comment)
        {
            var commentToUpdate = await _commentManager.UpdateAsync(comment);

            if (commentToUpdate == null)
            {
                throw new ApplicationException("Comment not updated.");
            }
            return Ok(commentToUpdate);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _commentManager.DeleteAsync(id);
            return NoContent();
        }
    }
}