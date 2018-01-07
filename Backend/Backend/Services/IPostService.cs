using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO;
using Backend.Models;

namespace Backend.Services
{
    public interface IPostService
    {
        Task<ICollection<PostDto>> GetAll(int offset, int limit);
        Task<PostDto> Get(int id);
        Task<int> Create(PostDto post);
        Task<int> Update(PostDto post, int id);
        Task<int> Delete(int id);
    }
}
