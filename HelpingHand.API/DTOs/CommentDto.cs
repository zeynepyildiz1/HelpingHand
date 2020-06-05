using HelpingHandProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHandProject.API.DTOs
{
    public class CommentDto
    {
        public CommentDto(Comment comment)
        {
            Id = comment.Id;
            CommentText = comment.CommentText;
            CommentDate = comment.CommentDate;
            UserId = comment.UserId;
            PostId = comment.PostId;
            User = new UserDto(comment.User);
            Post = new PostDto(comment.Post);
        }
        public CommentDto()
        {
        }
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public UserDto User { get; set; }
        public PostDto Post { get; set; }
        //public Post Post { get; set; }
    }
}
