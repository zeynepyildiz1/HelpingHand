using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json.Schema;

namespace HelpingHandProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        private readonly ILikeService _likeService;
        private readonly IWebHostEnvironment _environment;

        private readonly IMapper _mapper;
        public UserController(IMapper mapper, IUserService userService, IWebHostEnvironment environment, ILikeService likeService, ICommentService commentService)
        {
            _likeService = likeService;
            _commentService = commentService;
            _mapper = mapper;
            _userService = userService;
            _environment = environment;
        }
        [Authorize]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            var userDtos = users.Select(p => new
            {
                p.Id,
               p.FirstName,
               p.LastName,
               p.Mail
              
            });
            return Ok(userDtos);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                IEnumerable<Claim> claims = User.Claims;
                string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
                User user = await _userService.GetByIdAsync(int.Parse(userId));
                var userDto = (_mapper.Map<LoginUserDto>(user));
                userDto.PostCount = _userService.UserPostCount(int.Parse(userId));
                userDto.NotificationCount = _likeService.LikeStatusCount(int.Parse(userId)) + _commentService.CommentStatusCount(int.Parse(userId));
                return Ok(userDto);
            }
            catch
            { 
                return NotFound();
            }
            
             
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddUserAsync([FromForm]UserDto user)
        {
            var email = await _userService.EmailCheck(user.Mail);
            
            if (email.Success)
            {
                try
                {
                   
                    if (user.image == null)
                    {
                        user.UserImage = "0.jpg";
                        var newPost = await _userService.AddAsync(_mapper.Map<User>(user));
                        return Created(string.Empty, _mapper.Map<UserDto>(newPost));
                    }
                    else
                    {
                        var newPost = await _userService.AddAsync(_mapper.Map<User>(user));
                        var resimler = Path.Combine(_environment.WebRootPath, "userimage");
                        var imageName = $"{newPost.Id}.jpg";

                        if (user.image.Length > 0)
                        {
                            using (var fileStream = new FileStream(Path.Combine(resimler, imageName), FileMode.Create))
                            {
                                await user.image.CopyToAsync(fileStream);
                            }
                        }
                        newPost.UserImage = imageName;
                        _userService.Update(newPost);
                        return Created(string.Empty, _mapper.Map<UserDto>(newPost));
                    }
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(email.ErrorMessage);
            }


        }
        [Authorize]
        [HttpPost]
        [Route("/api/user/uploaduser/{id}")]
        public async Task<ActionResult> UploadUser(int id, [FromForm]IFormFile image)
        {
            if (image == null)
            {
                return BadRequest();
            }
            
            var userDto = await _userService.GetByIdAsync(id);

            var resimler = Path.Combine(_environment.WebRootPath, "userimage");
            var imageName = $"{userDto.Id}.jpg";

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(resimler, imageName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }
            userDto.UserImage = imageName;
            _userService.Update(userDto);

            return Ok();
        }
        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> Update([FromForm]UserDto userDto)
        {
            var email = await _userService.EmailCheck(userDto.Mail);
            int loginuserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = await _userService.GetByIdAsync(loginuserId);
            if (userDto.FirstName != null) user.FirstName = userDto.FirstName;
            if (userDto.LastName != null) user.FirstName = userDto.LastName;
            if (userDto.FirstName != null) user.FirstName = userDto.FirstName;
            if (userDto.Password != null) user.Password = userDto.Password;
              if (userDto.DateOfBirth !=new DateTime()) user.DateOfBirth = userDto.DateOfBirth;
            if (userDto.PhoneNumber != null) user.PhoneNumber = userDto.PhoneNumber;
            if (userDto.Address != null) user.Address = userDto.Address;
            if (userDto.Mail != null)
            {
                if (email.Success)
                {
                    user.Mail = userDto.Mail;
                }
                else { return BadRequest(email.ErrorMessage); }
             }
            if (userDto.image != null)
            {
                var resimler = Path.Combine(_environment.WebRootPath, "userimage");//dizin bilgisi
              //  System.IO.File.SetAttributes(resimler, FileAttributes.Normal);
               // System.IO.File.Delete(resimler);
               if(user.UserImage!="0.jpg"){ System.IO.File.Delete(resimler + "\\" + user.UserImage);}
                var imageName = $"{user.Id}.jpg";
                using (var fileStream = new FileStream(Path.Combine(resimler, imageName), FileMode.Create))
                { await userDto.image.CopyToAsync(fileStream); }
              
                user.UserImage = imageName;
            }
            var update = _userService.Update(_mapper.Map<User>(user));
          return Ok(update);


        }

    }
}