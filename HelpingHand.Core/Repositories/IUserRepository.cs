using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Core.Repositories
{
   public interface IUserRepository:IRepository<User>
    {
     
        Task<User> FindByEmailandPassword(string email, string password);
        void SaveRefreshToken(int userId, string refreshToken);
        Task<User> GetUserWithRefreshToken(string refreshToken);
        void RemoveRefreshToken(User user);
        Task<User> EmailCheck(string email);
       
        int UserPostCount(int userId);
    }
}
