using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/comments")]
    public class CommentsController : Controller
    {
        private readonly ICommentService _service;

        public CommentsController(ICommentService service)
        {
            _service = service;
        }

        // GET: api/posts
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Produces(typeof(Comment))]
        public async Task<IActionResult> GetAll([FromQuery]int postId, [FromQuery]int offset = 0, [FromQuery]int limit = 50)
        {
            var comments = await _service.GetAllPostComments(offset, limit, postId);
            return Ok(comments);
        }

        // GET: api/posts/5
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}", Name = "GetComment")]
        [Produces(typeof(Comment))]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var comment = await _service.Get(id);
            return Ok(comment);
        }

        // POST: api/posts
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Produces(typeof(Comment))]
        public async Task<IActionResult> Post([Microsoft.AspNetCore.Mvc.FromBody]Comment comment, [FromQuery]int postId)
        {
            var id = await _service.Create(comment, postId);
            if(id == -1) return NotFound();
            return CreatedAtRoute("GetComment", new { id }, comment);
        }

        // PUT: api/posts/5
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [Microsoft.AspNetCore.Mvc.FromBody]Comment comment)
        {
            var updatedId = await _service.Update(comment, id);
            if (updatedId == -1) return NotFound();
            return Ok(updatedId);
        }

        // DELETE: api/posts/5
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result == -1) return NotFound();
            return Ok();
        }
    }
}