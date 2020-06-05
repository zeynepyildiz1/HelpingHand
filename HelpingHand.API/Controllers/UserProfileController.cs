using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HelpingHandProject.API.DTOs;
using HelpingHandProject.API.Resources;
using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpingHandProject.API.Controllers
{[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly ILikeService _likeService;

        private readonly IMapper _mapper;
        public UserProfileController(IMapper mapper, IUserService userService, ILikeService likeService, IPostService postService)
        {
            _mapper = mapper;
            _userService = userService;
            _postService = postService;
            _likeService = likeService;
        }
        [HttpGet]
        [Route("/api/userprofile/{userId}/{category}")]
        public async Task<IActionResult> GetUserPostById(int userId,bool category)
        {
            int loginuserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var posts = await _postService.GetUserPost(userId, category);
            var postDtos = posts.Select(p => new
            {
                p.Id,
                User = new UserDto(p.User),
                p.PostCategory,
                PostDate = p.PostDate == DateTime.Now.Date ? p.PostDate.ToString("HH:mm") : p.PostDate.ToString("MM/dd HH:mm"),
                p.PostImage,
                p.PostText,
                LikeCount = _likeService.CountLike(p.Id),
                UserLike = _likeService.UserFindLike(loginuserId, p.Id) == null ? false : true
            });
            return Ok(postDtos);

        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
               
                User user = await _userService.GetByIdAsync(userId);
                var userDto = (_mapper.Map<LoginUserDto>(user));
                userDto.PostCount = _userService.UserPostCount(userId);

                return Ok(userDto);
            }
            catch
            {
                return NotFound();
            }


        }
    }
}