using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO;
using Backend.Models;

namespace Backend.Services
{
    public interface ICommentService
    {
        Task<ICollection<CommentDto>> GetAllPostComments(int offset, int limit, int postId);
        Task<CommentDto> Get(int commentId);
        Task<int> Create(CommentDto comment, int postId);
        Task<int> Update(CommentDto comment, int commentId);
        Task<int> Delete(int commentId);
    }
}
