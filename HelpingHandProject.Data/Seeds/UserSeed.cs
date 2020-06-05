using HelpingHandProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpingHandProject.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id=1,
                  
                    FirstName="Zeynep",
                    LastName="Yıldız",
                    Password="123456",
                    DateOfBirth= new DateTime(1998,01,16),
                    PhoneNumber="05349286464",
                    Mail="azeynepyildiz1@gmail.com",
                   
                },
                new User 
                {
                    Id = 2,
                   
                    FirstName = "Ali",
                    LastName = "Şahin",
                    Password = "123456",
                    DateOfBirth = new DateTime(2001, 08, 31),
                    PhoneNumber = "05349286464",
                    Mail = "zeyeess@gmail.com",
                
                },
                new User
                {
                    Id = 3,
                  
                    FirstName = "İrem",
                    LastName = "Yıldırım",
                    Password = "123456",
                    DateOfBirth = new DateTime(1991, 08, 14),
                    PhoneNumber = "05349286464",
                    Mail = "irem@gmail.com",
                   
                }
                );
        }
    }
}
