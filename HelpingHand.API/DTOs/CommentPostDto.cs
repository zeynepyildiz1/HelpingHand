using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHandProject.API.DTOs
{
    public class CommentPostDto
    {
     
        public bool PostCategory { get; set; }
        public string PostText { get; set; }
        public string PostImage { get; set; }

        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
     
    }
}
