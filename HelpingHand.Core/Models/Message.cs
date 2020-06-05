using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HelpingHandProject.Core.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public string MessageImg { get; set; }
        public DateTime MessageDate { get; set; }

        public int? SenderID { get; set; }
        public virtual User Sender { get; set; }

        public int? ReceiverID { get; set; }
        public virtual User Receiver { get; set; }

    }
}
