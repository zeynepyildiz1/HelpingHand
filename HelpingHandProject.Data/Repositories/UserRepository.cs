using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Repositories;
using HelpingHandProject.Core.Security.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        private TokenOptions _tokenOptions;
        private TokenOptions tokenOptions;

        //Base'den gelen _context'i AppDbContext'e dönüştür.
        public UserRepository(AppDbContext context, IOptions<TokenOptions> tokenOptions) : base(context)
        {
            _tokenOptions = tokenOptions.Value;
            //Repositoryden gelen bir construtor olduğu için base'e contexti yolluyoruz.
        }

        public UserRepository(AppDbContext context, TokenOptions tokenOptions) : base(context)
        {
            this.tokenOptions = tokenOptions;
        }

        public async Task<User> FindByEmailandPassword(string email, string password)
        {
         return await _appDbContext.Users.Where(u => u.Mail == email && u.Password == password).FirstOrDefaultAsync();
        }
      
        public async Task<User> GetUserWithRefreshToken(string refreshToken)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
      
        }

        public void RemoveRefreshToken(User user)
        {
            User newUser = _appDbContext.Users.Find(user.Id);
            newUser.RefreshToken = null;
            newUser.RefreshTokenEndDate = null;
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User newUser = _appDbContext.Users.Find(userId);
            newUser.RefreshToken = refreshToken;
            newUser.RefreshTokenEndDate = DateTime.Now.AddMinutes(tokenOptions.RefreshTokenExpiration);
        }

        public async Task<User> EmailCheck(string email)
        {
        return await _appDbContext.Users.Where(u=>u.Mail==email).FirstOrDefaultAsync();
          
        }
    
        public int UserPostCount(int userId)
        {
            return _appDbContext.Posts.Where(x => x.UserId == userId).Count();
        }

    }
}
