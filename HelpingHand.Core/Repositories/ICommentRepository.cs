using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Core.Repositories
{
   public interface ICommentRepository:IRepository<Comment>
    {
        ICollection<Comment> GetComment(int postId);
        int CountComment(int postId);
        Task<ICollection<Comment>> UserPostComment(int userId);
        int CommentStatusCount(int userId);
    }
}
