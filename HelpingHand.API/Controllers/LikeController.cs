using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpingHandProject.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public LikeController(IMapper mapper, ILikeService likeService, ICommentService commentService)
        {
            _mapper = mapper;
            _likeService = likeService;
            _commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _likeService.GetAllAsync();
            //automapper: dataları birbirine dönüştürür
            //
            return Ok(categories );
        }
        [HttpPost]
        public async Task<IActionResult> SaveLike(Like like) 
        {

            int loginuserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            like.UserId = loginuserId;
            like.LikeStatus = false;
            like.LikeDate = DateTime.Now;
            var userlike = await _likeService.FindLike(like);
            if (userlike!=null)
            {
                _likeService.Remove(userlike);
                return NoContent();
            }
            else { 
          var newLike= await _likeService.AddAsync(like);
          return Created(string.Empty, newLike);}
        }
        [HttpPost]
        [Route("/api/like/showlikes")]

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            var category = _likeService.GetByIdAsync(id).Result;
            _likeService.Remove(category);
            return NoContent();
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateLike(int id)
        {
            var Like = await _likeService.GetByIdAsync(id);
            Like.LikeStatus = true;
            var newLike=_likeService.Update(Like);
            return Created(string.Empty,newLike);
        }
        [HttpGet]
        [Route("/api/like/notification")]
        public async Task<IActionResult> Notification()
        {
            int loginuserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var posts = await _likeService.UserPostLike(loginuserId);
            var comments = await _commentService.UserPostComment(loginuserId);

            var postDtos = posts.Select(p => new
            {
                p.Id,
                p.UserId,
                p.PostId,
                p.LikeStatus,
                PostUserId = p.Post.UserId,
                PostUserName = p.User.FirstName + " " + p.User.LastName,
                PostUserImage = p.User.UserImage,
                PostText = p.Post.PostText,
                Date = p.LikeDate,
                Comments = comments.Select(c => new
                {
                    c.Id,
                    c.UserId,
                    c.PostId,
                    c.CommentStatus,
                    c.CommentText,
                    CommentUserId = c.Post.UserId,
                    CommentUserName = c.User.FirstName + " " + c.User.LastName,
                    CommentUserImage = c.User.UserImage,
                    PostText = c.Post.PostText,
                    Date = c.CommentDate,

                })

            }) ;
            return Ok(postDtos);
        }

    }
}