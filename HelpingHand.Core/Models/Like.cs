using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HelpingHandProject.Core.Models
{
    public class Like
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public virtual User User { get; set; } 
        public virtual Post Post { get; set; }
        public bool LikeStatus { get; set; }
        public DateTime LikeDate { get; set; }
    }
}
