﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<Post> Get(int id)
        {
            var post = await _repository.Get(id);
            return post;
        }

        public async Task<ICollection<Post>> GetAll(int offset, int limit)
        {
            var posts = await _repository.GetAll(offset, limit);
            return posts;
        }

        public async Task<int> Create(Post newPost)
        {
            var post = await _repository.Create(newPost);
            return post;
        }

        public async Task<int> Update(Post newPost)
        {
            var post = await _repository.Update(newPost);
            return post;
        }

        public async Task<int> Delete(int id)
        {
            var post = await _repository.Delete(id);
            return post;
        }
    }
}
