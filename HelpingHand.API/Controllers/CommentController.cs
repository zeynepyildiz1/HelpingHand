using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HelpingHandProject.API.DTOs;
using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Repositories;

using HelpingHandProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpingHandProject.API.Controllers
{[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
           
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            comment.UserId = userId;
            comment.CommentDate = DateTime.Now;
            var newComment =await _commentService.AddAsync(comment);
            return Created(string.Empty, newComment);
        }
        [HttpGet("{id}")]
        public  IActionResult GetComment(int id)
        {
            var comment = _commentService.GetComment(id);
         
            var commentDtos = comment.Select(se => new
            {
                se.Id,
                se.CommentText,
                PostDate = se.CommentDate == DateTime.Now ? se.CommentDate.ToString("HH:mm") : se.CommentDate.ToString("MM/dd HH:mm"),
                se.UserId,
                se.PostId,
                User = new UserDto(se.User),
                Post = new PostDto(se.Post)

            }).ToList();
            return Ok(commentDtos);

        }
        [HttpDelete("remove/{id}")]
        public IActionResult Remove(int id)
        {
            var post = _commentService.GetByIdAsync(id).Result;
            _commentService.Remove(post);
            return NoContent();

        }
        [HttpPost("updatecomment/{id}")]
        public async Task<IActionResult> UpdateComment(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);
            comment.CommentStatus = true;
            var newComment = _commentService.Update(comment);
            return Created(string.Empty, newComment);
        }

    }
}