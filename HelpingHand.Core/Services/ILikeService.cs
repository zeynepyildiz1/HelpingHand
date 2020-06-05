using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Core.Services
{
    public interface ILikeService : IService<Like>
    {
       public int CountLike(int postId);
         public Task<Like> FindLike(Like like);
        public Like UserFindLike(int userId, int postId);
        public Task<ICollection<Like>> UserPostLike(int userId);
        public int LikeStatusCount(int userId);
    }
}
