using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Database;
using Backend.DTO;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DbSet<Comment> _comments;
        private readonly DbSet<Post> _posts;
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public CommentRepository(DatabaseContext context, IMapper mapper)
        {
            _comments = context.Comments;
            _posts = context.Posts;
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentDto> Get(int commentId)
        {
            var comment = await _comments.FindAsync(commentId);
            return _mapper.Map<Comment, CommentDto>(comment);
        }

        public async Task<ICollection<CommentDto>> GetAllPostComments(int offset, int limit, int postId)
        {
            var result = await  _comments
                .Where(u => u.PostId == postId)
                .OrderByDescending(p => p.Date)
                .Skip(offset)
                .Take(limit)
                .ToArrayAsync();
            return _mapper.Map<ICollection<Comment>, ICollection<CommentDto>>(result); ;
        }

        public async Task<int> Create(CommentDto newComment, int postId)
        {
            var post = await _posts.FindAsync(postId);
            if (post == null) return -1;
            Comment comment = new Comment
            {
                Email = newComment.Email,
                Text = newComment.Text,
                PostId = postId,
                Post = post,
                Date = DateTime.Now
            };
            post.CommentsCount += 1;
            await _comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment.Id;
        }

        public async Task<int> Update(CommentDto newComment, int commentId)
        {
            var comment = await _comments.FindAsync(commentId);
            if (comment == null) return -1;
            comment.Text = newComment.Text;
            comment.Email = newComment.Email;
            comment.Date = DateTime.Now;
            await _context.SaveChangesAsync();
            return commentId;
        }

        public async Task<int> Delete(int commentId)
        {
            var found = await _comments.FindAsync(commentId);
            if (found == null)
                return -1;
            var post = await _posts.FindAsync(found.PostId);
            if (post == null)
                return -1;
            post.CommentsCount -= 1;
            _context.Remove(found);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
