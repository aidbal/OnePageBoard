using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAll(int offset, int limit);
        Task<Post> Get(int id);
        Task<int> Create(Post post);
        Task<int> Update(Post post, int id);
        Task<int> Delete(int id);
    }
}
