using HelpingHandProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpingHandProject.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.PostCategory).IsRequired();
           builder.Property(x => x.PostText).HasMaxLength(300);
            builder.Property(x => x.PostImage).HasMaxLength(500);
          //  builder.Property(x => x.PostImage).HasColumnType("image");
            builder.Property(x => x.PostDate).IsRequired();
         /* builder.HasOne(x => x.User)
                .WithMany(x => x.Post)
                .HasForeignKey(x => x.UserId);
           */
        }
    }
}
