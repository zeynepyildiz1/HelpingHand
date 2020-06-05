using HelpingHandProject.Core.Models;
using HelpingHandProject.Data.Configurations;
using HelpingHandProject.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpingHandProject.Data
{
    public class AppDbContext:DbContext
    {
        //nase keyworduyle optionsı al ana metoda gonder
        public AppDbContext(DbContextOptions<AppDbContext>options):base
            (options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messsages { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
           modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
           modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
          modelBuilder.ApplyConfiguration(new UserSeed());
      modelBuilder.ApplyConfiguration(new PostSeed(new int[] { 1, 2, 3 }));
           modelBuilder.ApplyConfiguration(new CommentSeed(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }));
        }
    }
}
