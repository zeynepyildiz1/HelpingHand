using HelpingHandProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpingHandProject.Core.Security.Token
{
   public interface ITokenHandler
    {
        AccessToken CreateAccesToken(User user);
        void RevokeRefreshToken(User user);
    }
}
