using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Comment> Get(int commentId)
        {
            var comment = await _repository.Get(commentId);
            return comment;
        }

        public async Task<ICollection<Comment>> GetAllPostComments(int offset, int limit, int postId)
        {
            var comments = await _repository.GetAllPostComments(offset, limit, postId);
            return comments;
        }

        public async Task<int> Create(Comment newComment, int postId)
        {
            var comment = await _repository.Create(newComment, postId);
            return comment;
        }

        public async Task<int> Update(Comment newComment, int commentId)
        {
            var comment = await _repository.Update(newComment, commentId);
            return comment;
        }

        public async Task<int> Delete(int commentId)
        {
            var post = await _repository.Delete(commentId);
            return post;
        }
    }
}
