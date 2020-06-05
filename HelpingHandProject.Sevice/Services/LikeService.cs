using HelpingHandProject.Core.IUnitOfWorks;
using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Repository;
using HelpingHandProject.Core.Services;
using HelpingHandProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Service.Services
{
   public class LikeService : Service<Like>, ILikeService
    {
        public LikeService(IUnitOfWork unitOfWork, IRepository<Like> repository) : base
          (unitOfWork, repository)
        {

        }

        public int CountLike(int postId)
        {
           return _unitOfWork.Likes.CountLike(postId);
        }

    

        public async Task<Like> FindLike(Like like)
        {
            return await _unitOfWork.Likes.FindLike(like);
        
        }

        public int LikeStatusCount(int userId)
        {
            return _unitOfWork.Likes.LikeStatusCount(userId);
        }

        public   Like UserFindLike(int userId, int postId)
        {
            return   _unitOfWork.Likes.UserFindLike(userId, postId);
            
        }

        public async Task<ICollection<Like>> UserPostLike(int userId)
        {
            return await _unitOfWork.Likes.UserPostLike(userId);
        }
      

    }
}
