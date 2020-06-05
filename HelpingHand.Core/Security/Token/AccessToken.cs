using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Sources;

namespace HelpingHandProject.Core.Security.Token
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
      
    }
}
