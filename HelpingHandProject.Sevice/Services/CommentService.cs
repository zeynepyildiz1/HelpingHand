using HelpingHandProject.Core.IUnitOfWorks;
using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Repository;
using HelpingHandProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Service.Services
{
    public class CommentService : Service<Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IRepository<Comment> repository) : base
       (unitOfWork, repository)
        {

        }

        public int CommentStatusCount(int userId)
        {
            return _unitOfWork.Comments.CommentStatusCount(userId);
        }

        public int CountComment(int postId)
        {
            return _unitOfWork.Comments.CountComment(postId);
        }

        public ICollection<Comment> GetComment(int postId)
        {
            return _unitOfWork.Comments.GetComment(postId);
        }

        public Task<ICollection<Comment>> UserPostComment(int userId)
        {
            return _unitOfWork.Comments.UserPostComment(userId);
        }
    }
}
