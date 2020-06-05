using HelpingHandProject.Core.IUnitOfWorks;
using HelpingHandProject.Core.Repositories;
using HelpingHandProject.Core.Security.Token;
using HelpingHandProject.Data.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private IPostRepository _postRepository;
        private ILikeRepository _likeRepository;
        private IUserRepository _userRepository;
        private ICommentRepository _commentRepository;
        private readonly TokenOptions _tokenOptions;


        public IPostRepository Posts => _postRepository = _postRepository ??
            new PostRepository(_appDbContext);

        public ILikeRepository Likes => _likeRepository = _likeRepository ??
            new LikeRepository(_appDbContext);

        public IUserRepository Users => _userRepository=_userRepository??
            new UserRepository(_appDbContext,_tokenOptions);

        public ICommentRepository Comments => _commentRepository = _commentRepository ??
            new CommentRepository(_appDbContext);

        public UnitOfWork(AppDbContext appDbContext, IOptions<TokenOptions> tokenoptions)
        {
            _tokenOptions = tokenoptions.Value;
            _appDbContext = appDbContext;
        }
        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
