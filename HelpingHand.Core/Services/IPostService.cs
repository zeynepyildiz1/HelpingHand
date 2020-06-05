using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Core.Services
{
    public interface IPostService : IService<Post>
    {
        public Task<List<Post>> GetPostWithUser();
       public Task<List<Post>> GetUserPost(int id,bool category);
        public Task<List<Post>> GetPostByCategory(bool category);
     

    }
}
