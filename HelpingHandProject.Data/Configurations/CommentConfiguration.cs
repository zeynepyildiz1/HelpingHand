using HelpingHandProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpingHandProject.Data.Configurations
{
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
      
            builder.Property(x => x.CommentText).IsRequired().HasMaxLength(500);
            builder.Property(x => x.CommentDate).IsRequired();
            builder.Property(x => x.PostId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
