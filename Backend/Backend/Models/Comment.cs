using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        public string Text { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public int PostId { get; set; }

        // Link to existing Post class 
        public virtual Post Post { get; set; }
    }
}
