using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Core.Repositories
{
   public interface ILikeRepository :IRepository<Like>
    {
       int CountLike(int postId);
        int LikeStatusCount(int userId);
        Task<Like> FindLike(Like like);
       Like UserFindLike(int userId,int postId);
        Task<ICollection<Like>> UserPostLike(int userId);

    }
}
