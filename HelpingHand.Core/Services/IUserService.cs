using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Response;
using HelpingHandProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Core.Services
{
   public interface IUserService: IService<User>
    {
        public Task<BaseResponse<User>> FindByEmailandPassword(string email, string password);
        public  void SaveRefreshToken(int userId, string refreshToken);
        public Task<BaseResponse<User>> GetUserWithRefreshToken(string refreshToken);
        public  void RemoveRefreshToken(User user);
        public Task<BaseResponse<User>> EmailCheck(string email);
       
        public int UserPostCount(int userId);
    }
}
