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
    public class PostService : Service<Post>, IPostService
    {
        public PostService(IUnitOfWork unitOfWork, IRepository<Post> repository) : base
          (unitOfWork, repository)
        {

        }

        public async Task<List<Post>> GetPostByCategory(bool category)
        {
            return await _unitOfWork.Posts.GetPostByCategory(category);
        }

        public async Task<List<Post>> GetPostWithUser()
        {
            return await _unitOfWork.Posts.GetPostWithUser();
        }

        public async Task<List<Post>> GetUserPost(int id,bool category)
        {
            return await _unitOfWork.Posts.GetUserPost(id, category);
        }
    }
}
