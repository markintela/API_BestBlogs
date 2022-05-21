using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Management.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Domain;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostManager _postManager;

        public PostController(ILogger<PostController> logger, IPostManager postManager)
        {
            _logger = logger;
            _postManager = postManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postManager.GetAllAsync();
            if (posts  == null)
            {
                throw new KeyNotFoundException("Post list is empty.");
            }
            return Ok(posts);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var post = await _postManager.GetAsync(id);
            if (post == null)
            {
                throw new KeyNotFoundException("Post not found.");
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            var coommentToCreate = await _postManager.CreateAsync(post);
            if (coommentToCreate == null)
            {
                throw new ApplicationException("Post not created.");

            }
            return CreatedAtAction(nameof(Get), new { id = coommentToCreate.Id }, coommentToCreate);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Post post)
        {
            var postToUpdate = await _postManager.UpdateAsync(post);

            if (postToUpdate == null)
            {
                throw new ApplicationException("Post not updated.");
            }
            return Ok(postToUpdate);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _postManager.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id:guid}/comments")]
        public async Task<IActionResult> GetComments([FromRoute] Guid id)
        {
            await _postManager.DeleteAsync(id);
            return NoContent();
        }
    }
}