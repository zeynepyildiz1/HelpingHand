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
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        //Base'den gelen _context'i AppDbContext'e dönüştür.
        public PostRepository(AppDbContext context) : base(context)
        {
            //Repositoryden gelen bir construtor olduğu için base'e contexti yolluyoruz.
        }

        public async Task<List<Post>> GetPostWithUser()
        {
           var posts= await _appDbContext.Posts.Include(x => x.User).OrderByDescending(x => x.Id).ToListAsync();
            return posts;
        }
        public async Task<List<Post>> GetPostByCategory(bool category)
        {
            var posts = await _appDbContext.Posts.Include(x => x.User).Where(x=>x.PostCategory== category).OrderByDescending(x=>x.Id).ToListAsync();
            return posts;
        }
     

        public async Task<List<Post>> GetUserPost(int id,bool category)
        {
            var posts = await _appDbContext.Posts.Include(x => x.User).Where(x => x.UserId== id&& x.PostCategory == category).OrderByDescending(x => x.Id).ToListAsync();
            return posts;
        }

     

        /*  var resimler = Path.Combine(_environment.WebRootPath, "resimler");
                if (musteri.ResimDosyasi.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(resimler, musteri.ResimDosyasi.FileName), FileMode.Create))
                    {
                        await musteri.ResimDosyasi.CopyToAsync(fileStream);
                    }
                }
                musteri.ResimYolu = musteri.ResimDosyasi.FileName;*/

    }
}
