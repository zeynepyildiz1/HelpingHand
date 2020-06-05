using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HelpingHandProject.API.DTOs;
using HelpingHandProject.Core.Response;
using HelpingHandProject.Core.Security.Token;
using HelpingHandProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace HelpingHandProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        public async Task<IActionResult> AccessToken(LoginResouce loginResource)
        {
            BaseResponse<AccessToken> accessTokenResponse =await _authenticationService.CreateAccessToken(loginResource.Email, loginResource.Password);
            if (accessTokenResponse.Success)
            {
                var response = HttpContext.Response;
                response.Headers.Add("Set-Cookie", $"Authorization=Bearer {accessTokenResponse.Extra.Token}");
               
                return Ok(accessTokenResponse.Extra);
            }
            else return BadRequest(accessTokenResponse.ErrorMessage);
          
        }
        [HttpPost]
        public async Task<IActionResult> RefreshToken(TokenResource tokenResource)
        {
            BaseResponse<AccessToken> accessTokenResponse = await _authenticationService.CreateAccessTokenByRefreshToken(tokenResource.RefreshToken);

            if (accessTokenResponse.Success)
            {
                // response2 = HttpContext.Response.Headers.Add;
              
                //response.Headers.Add("Set-Cookie","Authorization", $"Bearer {accessTokenResponse.Extra.Token}");
                // ​response.AddHeader("Set-Cookie", "SID=31d4d96e407aad42; Path=/; Secure; HttpOnly");
               
                return Ok(accessTokenResponse.Extra);
            }
            else
            {
                return BadRequest(accessTokenResponse.ErrorMessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(TokenResource tokenResource)
        {
           BaseResponse<AccessToken> accessToken = await _authenticationService.RevokeRefreshToken(tokenResource.RefreshToken);

            if (accessToken.Success)
            {
                return Ok(accessToken.Extra);
            }
            else
            {
                return BadRequest(accessToken.ErrorMessage);
            }
        }
    }
}