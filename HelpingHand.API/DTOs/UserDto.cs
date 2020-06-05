using HelpingHandProject.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHandProject.API.DTOs
{
    public class UserDto
    {
        public UserDto(User user)
        {
            
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserImage = user.UserImage;
            DateOfBirth = user.DateOfBirth;
            PhoneNumber = user.PhoneNumber;
            Mail = user.Mail;
      
        }

        public UserDto()
        {
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImage { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        public IFormFile image { get; set; }
        public string Address { get; set; }
       

    }
}
