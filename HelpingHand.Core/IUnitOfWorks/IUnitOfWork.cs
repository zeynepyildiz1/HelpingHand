using HelpingHandProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHandProject.Core.IUnitOfWorks
{
    public interface IUnitOfWork
    {
      ICommentRepository Comments { get; }
        IUserRepository Users { get; }
        ILikeRepository Likes { get; }
        IPostRepository Posts { get; }
        Task CommitAsync();
        void Commit();

    }
}

