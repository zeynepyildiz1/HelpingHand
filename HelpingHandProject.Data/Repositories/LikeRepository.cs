using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Data.Repositories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        //Base'den gelen _context'i AppDbContext'e dönüştür.
        public LikeRepository(AppDbContext context) : base(context)
        {
            //Repositoryden gelen bir construtor olduğu için base'e contexti yolluyoruz.
        }

      
        public int CountLike(int postId)
        {
         return  _appDbContext.Likes.Where(x => x.PostId == postId).Count();
          
        }

        public async Task<Like> FindLike(Like like)
        {
          var findlike=await _appDbContext.Likes.Where(x => x.UserId == like.UserId && x.PostId == like.PostId).FirstOrDefaultAsync();
            return findlike;
        }

        public async Task<ICollection<Like>> UserPostLike(int userId)
        {

            var posts = await _appDbContext.Likes.Include(x => x.Post).Include(x=>x.User).Where(x=>x.Post.Id==x.PostId&& x.Post.UserId==userId&& x.UserId == x.User.Id).OrderByDescending(x => x.Id).ToListAsync();
            return posts;
        }

        public Like UserFindLike(int userId, int postId)
        {
            var findlike =  _appDbContext.Likes.Where(x => x.UserId == userId && x.PostId == postId).FirstOrDefault();
            return findlike;
        }

        public int LikeStatusCount(int userId)
        {
             var posts = _appDbContext.Likes.Include(x => x.Post).Include(x=>x.User).Where(x=>x.Post.Id==x.PostId&& x.Post.UserId==userId&& x.UserId == x.User.Id&& x.LikeStatus==false).OrderByDescending(x => x.Id).ToList().Count();
            return posts;
        }
    }
}
