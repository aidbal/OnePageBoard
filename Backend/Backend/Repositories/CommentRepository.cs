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

        public async Task<Comment> Get(int commentId)
        {
            var comment = await _comments.FindAsync(commentId);
            return comment;
        }

        public async Task<ICollection<Comment>> GetAllPostComments(int offset, int limit, int postId)
        {
            var result = await  _comments
                .Where(u => u.PostId == postId)
                .OrderBy(p => p.Date)
                .Skip(offset)
                .Take(limit)
                .ToArrayAsync();
            return result;
        }

        public async Task<int> Create(Comment newComment, int postId)
        {
            var post = await _posts.FindAsync(postId);
            if (post == null) return -1;
            newComment.PostId = postId;
            newComment.Post = post;
            await _comments.AddAsync(newComment);
            await _context.SaveChangesAsync();
            return newComment.Id;
        }

        public async Task<int> Update(Comment newComment, int commentId)
        {
            var comment = await _comments.FindAsync(commentId);
            if (comment == null) return -1;
            comment.Text = newComment.Text;
            comment.Email = newComment.Email;
            comment.Date = newComment.Date;
            await _context.SaveChangesAsync();
            return commentId;
        }

        public async Task<int> Delete(int commentId)
        {
            var found = await _comments.FindAsync(commentId);
            if (found == null)
                return -1;
            _context.Remove(found);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
