using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HelpingHandProject.Core.Models
{
   public class User
    {
       public User()
        {
            Post = new Collection<Post>();
         
        }
        public int Id { get; set; }
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImage { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Address { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public virtual ICollection<Post> Post { get; set; }
      
        public virtual ICollection<Like> Like { get; set; }
        // public ICollection<Message> SendMessage { get; set; }
        // public ICollection<Message> ReceiverMessage { get; set; }


    }
}
