using HelpingHandProject.Core.Security.Token;
using HelpingHandProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Response;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using HelpingHandProject.Core.Service;
using HelpingHandProject.Core.IUnitOfWorks;
using HelpingHandProject.Core.Repository;

namespace HelpingHandProject.Service.Services
{
   public class AuthenticationService:IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;
        public AuthenticationService(IUserService userService,ITokenHandler tokenHandler) 
        {
            _userService = userService;
            _tokenHandler = tokenHandler;

        }
      
        public async Task<BaseResponse<AccessToken>> CreateAccessToken(string email, string password)
        {
            BaseResponse<User> userResponse = await _userService.FindByEmailandPassword(email, password);

            if (userResponse.Success)
            {
                AccessToken accessToken = _tokenHandler.CreateAccesToken(userResponse.Extra);

                _userService.SaveRefreshToken(userResponse.Extra.Id, accessToken.RefreshToken);

                return new BaseResponse<AccessToken>(accessToken);
            }
            else
            {
                return new BaseResponse<AccessToken>(userResponse.ErrorMessage);
            }


        }

      

        public async Task<BaseResponse<AccessToken>> CreateAccessTokenByRefreshToken(string refreshToken)
        {
        

            BaseResponse<User> userResponse = await _userService.GetUserWithRefreshToken(refreshToken);

            if (userResponse.Success)
            {
                if (userResponse.Extra.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken accessToken = _tokenHandler.CreateAccesToken(userResponse.Extra);

                    _userService.SaveRefreshToken(userResponse.Extra.Id, accessToken.RefreshToken);

                    return new BaseResponse<AccessToken>(accessToken);
                }
                else
                {
                    return new BaseResponse<AccessToken>("refreshtoken suresi dolmus");
                }
            }
            else
            {
                return new BaseResponse<AccessToken>("refresh token bulunamadı");
            }
        }

        public async Task<BaseResponse<AccessToken>> RevokeRefreshToken(string refreshToken)
        {
            BaseResponse<User> userResponse = await _userService.GetUserWithRefreshToken(refreshToken);

            if (userResponse.Success)
            {
                _userService.RemoveRefreshToken(userResponse.Extra);

                return new BaseResponse<AccessToken>(new AccessToken());
            }
            else
            {
                return new BaseResponse<AccessToken>("refresh token bulunamadı.");
            }

          
        }
    }
}
