using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Backend.DTO;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/posts")]
    public class PostsController : Controller
    {
        private readonly IPostService _service;

        public PostsController(IPostService service)
        {
            _service = service;
        }

        // GET: api/posts
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Produces(typeof(PostDto))]
        public async Task<IActionResult> GetAll([FromQuery]int offset = 0, [FromQuery]int limit = 50)
        {
            var posts = await _service.GetAll(offset, limit);
            return Ok(posts);
        }

        // GET: api/posts/5
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}", Name = "GetPost")]
        [Produces(typeof(PostDto))]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var post = await _service.Get(id);
            return Ok(post);
        }
        
        // POST: api/posts
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Produces(typeof(PostDto))]
        public async Task<IActionResult> Post([Microsoft.AspNetCore.Mvc.FromBody]PostDto post)
        {
            var id = await _service.Create(post);
            return CreatedAtRoute("GetPost", new {id}, post);
        }
        
        // PUT: api/posts/5
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [Microsoft.AspNetCore.Mvc.FromBody]PostDto post)
        {
            var updatedId = await _service.Update(post, id);
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
