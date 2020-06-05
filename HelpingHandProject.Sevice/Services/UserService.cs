using HelpingHandProject.Core.IUnitOfWorks;
using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Repository;
using HelpingHandProject.Core.Response;
using HelpingHandProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
          public UserService(IUnitOfWork unitOfWork, IRepository<User> repository) : base
         (unitOfWork, repository)
          {

          }

        public async Task<BaseResponse<User>> EmailCheck(string email)
        {
            try
            {
                User user = await _unitOfWork.Users.EmailCheck(email);
                if (user == null)
                {
                   
                    return new BaseResponse<User>(user);
                }
                else
                {
                    return new BaseResponse<User>("Bu email adresi daha önce alınmış.");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"E-mail adresi aranırken bir hata meydana geldi:{ex.Message}");
            }
        }

        public async Task<BaseResponse<User>> FindByEmailandPassword(string email, string password)
          {
            try
            {
                User user = await _unitOfWork.Users.FindByEmailandPassword(email, password);
                if (user == null)
                {
                    return new BaseResponse<User>("Kullanıcı bulunamadı.");
                }
                else
                {
                    return new BaseResponse<User>(user);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"Kullanıcı bulunurken bir hata meydana geldi:{ex.Message}");
            }
        }

          public async Task<BaseResponse<User>> GetUserWithRefreshToken(string refreshToken)
          {
            try
            {
                User user = await _unitOfWork.Users.GetUserWithRefreshToken(refreshToken);

                if (user == null)
                {
                    return new BaseResponse<User>("Kullanıcı bulunamadı.");
                }
                else
                {
                    return new BaseResponse<User>(user);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"Kullanıcı bulunurken bir hata meydana geldi:{ex.Message}");
            }
        }

          public void RemoveRefreshToken(User user)
          {     
            try
            {
                _unitOfWork.Users.RemoveRefreshToken(user);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw new SystemException();
            }
        }

          public void SaveRefreshToken(int userId, string refreshToken)
          {
         
            try
            {
                _unitOfWork.Users.SaveRefreshToken(userId, refreshToken);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw new SystemException();
            }
        }



        public int UserPostCount(int userId)
        {
            return _unitOfWork.Users.UserPostCount(userId);
        }
    }
    }

