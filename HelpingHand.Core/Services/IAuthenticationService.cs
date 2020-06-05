using HelpingHandProject.Core.Response;
using HelpingHandProject.Core.Security.Token;
using HelpingHandProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Core.Services
{
    public interface IAuthenticationService 
    {
       public Task<BaseResponse<AccessToken>> CreateAccessToken(string email, string password);

        public Task<BaseResponse<AccessToken>> CreateAccessTokenByRefreshToken(string refreshToken);

        public Task<BaseResponse<AccessToken>> RevokeRefreshToken(string refreshToken);
    }
}
