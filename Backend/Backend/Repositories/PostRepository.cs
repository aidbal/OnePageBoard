using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly DbContext _context;

        public PostRepository(DatabaseContext context)
        {
            _posts = context.Posts;
            _context = context;
        }

        public async Task<Post> Get(int id)
        {
            var post = await _posts.FindAsync(id);
            return post;
        }

        public async Task<ICollection<Post>> GetAll(int offset, int limit)
        {
            var posts = await _posts
                .OrderByDescending(m => m.Id)
                .Skip(offset)
                .Take(limit)
                .ToArrayAsync();
            return posts;
        }

        public async Task<int> Create(Post newPost)
        {
            await _posts.AddAsync(newPost);
            await _context.SaveChangesAsync();
            return newPost.Id;
        }

        public async Task<int> Update(Post newPost)
        {
            var post = await _posts.FindAsync(newPost.Id);
            if (post == null) return -1;
            post.Text = newPost.Text;
            post.Title = newPost.Title;
            post.Email = newPost.Email;
            await _context.SaveChangesAsync();
            return newPost.Id;
        }

        public async Task<int> Delete(int id)
        {
            var found = await _posts.Where(post => post.Id == id).FirstOrDefaultAsync();
            if (found == null)
                return -1;
            _context.Remove(found);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
