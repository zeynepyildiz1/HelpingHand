using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Core.Services
{
  public  interface ICommentService:IService<Comment>
    {
        public ICollection<Comment> GetComment(int postId);
       public int CountComment(int postId);
        public Task<ICollection<Comment>> UserPostComment(int userId);
        public int CommentStatusCount(int userId);
    }
}
