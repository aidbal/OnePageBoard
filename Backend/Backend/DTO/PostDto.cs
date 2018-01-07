using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public int CommentsCount { get; set; }
    }
}
