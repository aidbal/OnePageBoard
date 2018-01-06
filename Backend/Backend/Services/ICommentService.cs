using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services
{
    public interface ICommentService
    {
        Task<ICollection<Comment>> GetAllPostComments(int offset, int limit, int postId);
        Task<Comment> Get(int commentId);
        Task<int> Create(Comment comment, int postId);
        Task<int> Update(Comment comment, int commentId);
        Task<int> Delete(int commentId);
    }
}
