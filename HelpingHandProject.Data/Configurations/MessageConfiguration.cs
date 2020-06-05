using HelpingHandProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpingHandProject.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
         //   builder.Property(x => x.MessageImg).HasColumnType("image");
            builder.Property(x => x.MessageText).IsRequired().HasMaxLength(500);
            builder.Property(x => x.MessageDate).IsRequired();
           // builder.Property(x => x.SenderId).IsRequired();
//builder.Property(x => x.ReceiverId).IsRequired();
            //builder.HasOptional(x => x.Sender).WithMany(x => x.SenderUser);
            // builder.HasOptional(x => x.Reciever).WithMany(x => x.RecieverUser);
          /*  builder.HasOne(x => x.Sender)
                .WithMany(x => x.SendMessage)
                .HasForeignKey(x => x.SenderId);
            builder.HasOne(x => x.Receiver)
              .WithMany(x => x.ReceiverMessage)
              .HasForeignKey(x => x.ReceiverId);
              */


        }
    }
}
