using HelpingHandProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpingHandProject.Data.Seeds
{
    public class CommentSeed : IEntityTypeConfiguration<Comment>
    { private readonly int[] _UserIds;
        private readonly int[] _PostIds;
        
        
        public CommentSeed(int[] UserIds, int[] PostIds)
        {
            _UserIds = UserIds;
            _PostIds = PostIds;
        }
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(
                new Comment
                {
                    Id = 1,
                    CommentText = "Mesaj atarsanız eğer ben yardımcı olabilirim",
                    CommentDate = new DateTime(2020, 11, 04),
                    UserId = _UserIds[0],
                    PostId = _PostIds[0]

                });
            builder.HasData(
               new Comment
               {
                   Id = 2,
                   CommentText = "İstanbulda da aynı sorun var.Yardımlarınızı bekliyoruz",
                   CommentDate = new DateTime(2020, 09, 04),
                   UserId = _UserIds[1],
                  PostId =  _PostIds[1] 

               });
        }
    }
    }

