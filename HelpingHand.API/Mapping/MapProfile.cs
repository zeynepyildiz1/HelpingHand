using AutoMapper;
using HelpingHandProject.API.DTOs;

using HelpingHandProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHandProject.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, LoginUserDto>();
            CreateMap<LoginUserDto, User>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
