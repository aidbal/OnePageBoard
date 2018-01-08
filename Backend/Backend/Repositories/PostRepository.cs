using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Database;
using Backend.DTO;
using Backend.Models;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DbSet<Post> _posts;
        private readonly DbSet<Comment> _comments;
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public PostRepository(DatabaseContext context, IMapper mapper)
        {
            _posts = context.Posts;
            _comments = context.Comments;
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostDto> Get(int id)
        {
            var post = await _posts.FindAsync(id);
            return _mapper.Map<Post, PostDto>(post);
        }

        public async Task<ICollection<PostDto>> GetAll(int offset, int limit)
        {
            var posts = await _posts
                .OrderByDescending(m => m.Id)
                .Skip(offset)
                .Take(limit)
                .ToArrayAsync();
            return _mapper.Map<ICollection<Post>, ICollection<PostDto>>(posts); ;
        }

        public async Task<int> Create(PostDto newPost)
        {
            Post post = new Post();
            post.Title = newPost.Title;
            post.Text = newPost.Text;
            post.Email = newPost.Email;
            post.Date = DateTime.Now;
            await _posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post.Id;
        }

        public async Task<int> Update(PostDto newPost, int id)
        {
            var post = await _posts.FindAsync(id);
            if (post == null) return -1;
            post.Text = newPost.Text;
            post.Title = newPost.Title;
            post.Email = newPost.Email;
            post.Date = DateTime.Now;
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<int> Delete(int id)
        {
            var found = await _posts.Where(post => post.Id == id).FirstOrDefaultAsync();
            if (found == null)
                return -1;
            _context.Remove(found);
            var comments = await _comments
                .Where(u => u.PostId == id)
                .ToArrayAsync();

            foreach (var comment in comments)
            {
                _context.Remove(comment);
            }
            await _context.SaveChangesAsync();
            return 1;
        }
        
    }
}
