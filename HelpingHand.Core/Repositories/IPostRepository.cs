using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Core.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<List<Post>> GetPostWithUser();
       
        Task<List<Post>> GetUserPost(int id,bool category);
        Task<List<Post>> GetPostByCategory(bool category);
    }
}
