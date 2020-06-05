using HelpingHandProject.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHandProject.API.DTOs
{
    public class PostDto
    {
        public PostDto(Post post)
        {
            PostCategory = post.PostCategory;
            PostText = post.PostText;
            PostImage = post.PostImage;
            PostDate = post.PostDate;
            UserId = post.UserId;
            User = new UserDto(post.User);

        }

        public PostDto()
        {
        }
        public int Id { get; set; }
        public bool PostCategory { get; set; }
        public string PostText { get; set; }
        public string PostImage { get; set; }
     
        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public IFormFile image { get; set; }

    }
}
