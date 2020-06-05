﻿// <auto-generated />
using System;
using HelpingHandProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelpingHandProject.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200506090458_AddToken")]
    partial class AddToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HelpingHandProject.Core.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommentDate = new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CommentText = "Mesaj atarsanız eğer ben yardımcı olabilirim",
                            PostId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CommentDate = new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CommentText = "İstanbulda da aynı sorun var.Yardımlarınızı bekliyoruz",
                            PostId = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("HelpingHandProject.Core.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("HelpingHandProject.Core.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int?>("ReceiverID")
                        .HasColumnType("int");

                    b.Property<int?>("SenderID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("SenderID");

                    b.ToTable("Messsages");
                });

            modelBuilder.Entity("HelpingHandProject.Core.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("PostCategory")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostImage")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("PostText")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostCategory = true,
                            PostDate = new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostText = "Dünya Sağlık Örgütü tarafından pandemi olarak belirtilen Koronavirüs`le mücadele sürecinde hastanemizdeki sağlık personelinin kullanabilmesi için aşağıdaki malzemelere ihtiyacımız bulunmaktadır.",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            PostCategory = true,
                            PostDate = new DateTime(2010, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostText = "Koronavirüs salgını nedeni ile azalan hasta sayımıza rağmen günde yaklaşık 150 hasta bakmaktayız. Dezenfektan temin etme konusunda sıkıntı yaşamaktayız.",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            PostCategory = true,
                            PostDate = new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostText = "Gelen hastaların ateşini temassız ölçebilmek için alından ölçen ateş ölçerler mevcut ihtiyacı olan hastaneler yollayabilirim.",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            PostCategory = true,
                            PostDate = new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostText = "Dünya Sağlık Örgütü tarafından pandemi olarak belirtilen Koronavirüs`le mücadele sürecinde hastanemizdeki sağlık personelinin kullanabilmesi için aşağıdaki malzemelere ihtiyacımız bulunmaktadır.",
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            PostCategory = false,
                            PostDate = new DateTime(2010, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostText = "İhtiyacı olan 3 öğrenciye burs vereceğim.",
                            UserId = 2
                        },
                        new
                        {
                            Id = 6,
                            PostCategory = false,
                            PostDate = new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostText = "Geçen seneden kalan ygs kitaplarım duruyor dileyene gönderebilirim.",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("HelpingHandProject.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nchar(11)")
                        .IsFixedLength(true)
                        .HasMaxLength(11);

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("RefreshTokenEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserImage")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1998, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Zeynep",
                            LastName = "Yıldız",
                            Mail = "azeynepyildiz1@gmail.com",
                            Password = "123456",
                            PhoneNumber = "05349286464",
                            RefreshTokenEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(2001, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ali",
                            LastName = "Şahin",
                            Mail = "zeyeess@gmail.com",
                            Password = "123456",
                            PhoneNumber = "05349286464",
                            RefreshTokenEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1991, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "İrem",
                            LastName = "Yıldırım",
                            Mail = "irem@gmail.com",
                            Password = "123456",
                            PhoneNumber = "05349286464",
                            RefreshTokenEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HelpingHandProject.Core.Models.Comment", b =>
                {
                    b.HasOne("HelpingHandProject.Core.Models.Post", "Post")
                        .WithMany("Comment")
                        .HasForeignKey("PostId");

                    b.HasOne("HelpingHandProject.Core.Models.User", "User")
                        .WithMany("Comment")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HelpingHandProject.Core.Models.Like", b =>
                {
                    b.HasOne("HelpingHandProject.Core.Models.Post", "Post")
                        .WithMany("Like")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpingHandProject.Core.Models.User", "User")
                        .WithMany("Like")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HelpingHandProject.Core.Models.Message", b =>
                {
                    b.HasOne("HelpingHandProject.Core.Models.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverID");

                    b.HasOne("HelpingHandProject.Core.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderID");
                });

            modelBuilder.Entity("HelpingHandProject.Core.Models.Post", b =>
                {
                    b.HasOne("HelpingHandProject.Core.Models.User", "User")
                        .WithMany("Post")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
