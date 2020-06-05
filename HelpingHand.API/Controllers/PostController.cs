using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HelpingHandProject.API.DTOs;
using HelpingHandProject.Core.Models;
using HelpingHandProject.Core.Service;
using HelpingHandProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpingHandProject.API.Controllers
{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ILikeService _likeService;
        private readonly ICommentService _commentService;
        private readonly IWebHostEnvironment _environment;

        private readonly IMapper _mapper;
        public PostController(IMapper mapper, IPostService postService, ILikeService likeService, IWebHostEnvironment environment, ICommentService commentService)
        {
            _mapper = mapper;
            _postService = postService;
            _likeService = likeService;
            _environment = environment;
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostWithUser()
        {
           
            var posts = await _postService.GetPostWithUser();
            var postDtos = posts.Select(p => new
            {
                p.Id,
                User = new UserDto(p.User),
                p.PostCategory,
                PostDate = p.PostDate == DateTime.Now.Date ? p.PostDate.ToString("HH:mm") : p.PostDate.ToString("MM/dd HH:mm"),
                p.PostImage,
                p.PostText,
                LikeCount = _likeService.CountLike(p.Id),
                CommentCount=_commentService.CountComment(p.Id)
            });
            return Ok(postDtos);
        }
       [HttpGet("{category}")]
        public async Task<IActionResult> GetPostByCategory(bool category)
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var posts = await _postService.GetPostByCategory(category);
            var postDtos = posts.Select(p => new
            {
                p.Id,
                User = new UserDto(p.User),
                p.UserId,
                p.PostCategory,
                PostDate =p.PostDate==DateTime.Now.Date?p.PostDate.ToString("HH:mm"):p.PostDate.ToString("MM/dd HH:mm"),
                p.PostImage,
                p.PostText,
                Comment = new List<CommentDto>(_commentService.GetComment(p.Id).Select(se => new CommentDto
                {
                   Id= se.Id,
                   CommentText= se.CommentText,
                   CommentDate =se.CommentDate,
                   UserId = se.UserId,
                   PostId=se.PostId,
                   User = new UserDto(p.User),

                })),
                LikeCount = _likeService.CountLike(p.Id),
                UserLike = _likeService.UserFindLike(userId, p.Id) == null ? false : true,
                CommentCount = _commentService.CountComment(p.Id)


            });
            return Ok(postDtos);
        }
         [HttpGet]
         [Route("/api/post/getuserpost/{category}")]
           public async Task<IActionResult> GetUserPostById(bool category)
           {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var posts = await _postService.GetUserPost(userId, category);
               var postDtos = posts.Select( p => new
               {
                   p.Id,
                   User = new UserDto(p.User),
                   p.PostCategory,
                 PostDate= p.PostDate == DateTime.Now.Date? p.PostDate.ToString("HH:mm") : p.PostDate.ToString("MM/dd HH:mm"),
                   p.PostImage,
                   p.PostText,
                   LikeCount = _likeService.CountLike(p.Id),
                   UserLike =  _likeService.UserFindLike(userId, p.Id) == null ? false : true,
                   CommentCount = _commentService.CountComment(p.Id)
               });
               return Ok(postDtos);

           }
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromForm]PostDto postDto)
        {
            try
            {
                int loginuserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                postDto.UserId = loginuserId;
                postDto.PostDate = DateTime.Now;
                var newPost = await _postService.AddAsync(_mapper.Map<Post>(postDto));
                if (postDto.image == null)
                {
                    return Created(string.Empty, _mapper.Map<PostDto>(newPost));
                }
                else
                {
                    var resimler = Path.Combine(_environment.WebRootPath, "img");
                    var imageName = $"{newPost.Id}.jpg";

                    if (postDto.image.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(resimler, imageName), FileMode.Create))
                        {
                            await postDto.image.CopyToAsync(fileStream);
                        }
                    }
                    newPost.PostImage = imageName;
                    _postService.Update(newPost);
                    return Created(string.Empty, _mapper.Map<PostDto>(newPost));
                }
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("/api/post/{id}")]
        public async Task<ActionResult> UploadPost(int id, [FromForm]IFormFile image)
        {
            if (image == null)
            {
                return BadRequest();
            }

            var postDto = await _postService.GetByIdAsync(id);

            var resimler = Path.Combine(_environment.WebRootPath, "img");
            var imageName = $"{postDto.Id}.jpg";

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(resimler, imageName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }
            postDto.PostImage = imageName;
            _postService.Update(postDto);

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var post = _postService.GetByIdAsync(id).Result;
            _postService.Remove(post);
            return NoContent();

        }
        
    }
}