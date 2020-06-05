using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HelpingHandProject.Core.Models
{
   public class Post
    { public Post()
        {
            Comment = new Collection<Comment>();
            Like = new Collection<Like>();
        }
        public int Id { get; set; }
        public bool PostCategory { get; set; }
        public string  PostText { get; set; }
        public string PostImage { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        
        public DateTime PostDate{ get; set; }
           
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public ICollection<Like> Like { get; set; }
    }
}
