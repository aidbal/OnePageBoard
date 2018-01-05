using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public String Date { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
