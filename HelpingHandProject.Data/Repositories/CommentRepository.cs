using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Data.Repositories
{
    public class CommentRepository:Repository<Comment>,ICommentRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        //Base'den gelen _context'i AppDbContext'e dönüştür.
        public CommentRepository(AppDbContext context) : base(context)
        {
            //Repositoryden gelen bir construtor olduğu için base'e contexti yolluyoruz.
        }

        public ICollection<Comment> GetComment(int postId)
        {
            var comment = _appDbContext.Comments.Include(x=>x.User).Include(x=>x.Post).ThenInclude(x=>x.User).Where(x => x.PostId == postId).ToList();
            return comment; 
        }

        public int CountComment(int postId)
        {
            return _appDbContext.Comments.Where(x => x.PostId == postId).Count();
        }

        public async Task<ICollection<Comment>> UserPostComment(int userId)
        {
            var posts = await _appDbContext.Comments.Include(x => x.Post).Include(x => x.User).Where(x => x.Post.Id == x.PostId && x.Post.UserId == userId && x.UserId == x.User.Id).OrderByDescending(x => x.Id).ToListAsync();
            return posts;
        }

        public int CommentStatusCount(int userId)
        {
            var posts =  _appDbContext.Comments.Include(x => x.Post).Include(x => x.User).Where(x => x.Post.Id == x.PostId && x.Post.UserId == userId && x.UserId == x.User.Id&&x.CommentStatus==false).OrderByDescending(x => x.Id).ToList().Count();
            return posts;
        }
    }
}
