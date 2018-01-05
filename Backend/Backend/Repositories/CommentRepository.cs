using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Database;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DbSet<Comment> _comments;
        private readonly DbSet<Post> _posts;
        private readonly DbContext _context;

        public CommentRepository(DatabaseContext context)
        {
            _comments = context.Comments;
            _posts = context.Posts;
            _context = context;
        }

        public async Task<Comment> Get(int id)
        {
            var post = await _comments.FindAsync(id);
            return post;
        }

        public async Task<ICollection<Comment>> GetAllPostComments(int offset, int limit, int postId)
        {
            var result = await  _posts
                .Where(u => u.Id == postId)
                .SelectMany(u => u.Comments)
                .OrderBy(p => p.Id)
                .Skip(offset)
                .Take(limit)
                .ToArrayAsync();
            return result;
        }

        public async Task<int> Create(Comment newComment, int postId)
        {
            var post = await _posts.FindAsync(postId);
            if (post == null) return -1;
            await _comments.AddAsync(newComment);
            post.Comments.Add(newComment);
            await _context.SaveChangesAsync();
            return newComment.Id;
        }

        public async Task<int> Update(Comment newComment)
        {
            var comment = await _comments.FindAsync(newComment.Id);
            if (comment == null) return -1;
            comment.Text = newComment.Text;
            comment.Email = newComment.Email;
            await _context.SaveChangesAsync();
            return newComment.Id;
        }

        public async Task<int> Delete(int id)
        {
            var found = await _comments.Where(comment => comment.Id == id).FirstOrDefaultAsync();
            if (found == null)
                return -1;
            _context.Remove(found);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
