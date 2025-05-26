using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using GESTION.Dto.Comment;
using GESTION.Services;

namespace GESTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _commentService.GetAllCommentsAsync();
            return Ok(comments);
        }

        // GET: api/Comment/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment([FromRoute] int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
                return NotFound();
            
            return Ok(comment);
        }

        // POST: api/Comment
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdComment = await _commentService.CreateCommentAsync(dto);
            return CreatedAtAction(nameof(GetComment), new { id = createdComment.IdComment }, createdComment);
        }

        // PUT: api/Comment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedComment = await _commentService.UpdateCommentAsync(id, dto);
            if (updatedComment == null)
                return NotFound();

            return Ok(updatedComment);
        }

        // DELETE: api/Comment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var success = await _commentService.DeleteCommentAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
