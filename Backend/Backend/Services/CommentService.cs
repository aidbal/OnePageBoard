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

        public async Task<Comment> Get(int id)
        {
            var comment = await _repository.Get(id);
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

        public async Task<int> Update(Comment newComment)
        {
            var comment = await _repository.Update(newComment);
            return comment;
        }

        public async Task<int> Delete(int id)
        {
            var post = await _repository.Delete(id);
            return post;
        }
    }
}
