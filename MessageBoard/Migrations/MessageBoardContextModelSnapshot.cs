﻿// <auto-generated />
using System;
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageBoard.Migrations
{
    [DbContext(typeof(MessageBoardContext))]
    partial class MessageBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MessageBoard.Models.Board", b =>
                {
                    b.Property<int>("BoardId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("BoardId");

                    b.ToTable("Boards");

                    b.HasData(
                        new
                        {
                            BoardId = 1,
                            Title = "Politics"
                        },
                        new
                        {
                            BoardId = 2,
                            Title = "Religions"
                        },
                        new
                        {
                            BoardId = 3,
                            Title = "Objectively Best Music Genres"
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("ParentThreadId");

                    b.Property<string>("PostBody");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("PostId");

                    b.HasIndex("ParentThreadId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            CreationDate = new DateTime(2020, 8, 17, 11, 31, 45, 66, DateTimeKind.Local).AddTicks(7010),
                            ParentThreadId = 1,
                            PostBody = "Lorem Ipsum",
                            Title = "Test Message",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.Thread", b =>
                {
                    b.Property<int>("ThreadId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("ParentBoardId");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("ThreadId");

                    b.HasIndex("ParentBoardId");

                    b.HasIndex("UserId");

                    b.ToTable("Threads");

                    b.HasData(
                        new
                        {
                            ThreadId = 1,
                            CreationDate = new DateTime(2020, 8, 17, 11, 31, 45, 61, DateTimeKind.Local).AddTicks(5620),
                            ParentBoardId = 1,
                            Title = "Test Message",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreationDate = new DateTime(2020, 8, 17, 11, 31, 45, 67, DateTimeKind.Local).AddTicks(4750),
                            UserName = "TestName"
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.Post", b =>
                {
                    b.HasOne("MessageBoard.Models.Thread", "ParentThread")
                        .WithMany("Posts")
                        .HasForeignKey("ParentThreadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MessageBoard.Models.User", "User")
                        .WithMany("UserPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MessageBoard.Models.Thread", b =>
                {
                    b.HasOne("MessageBoard.Models.Board", "ParentBoard")
                        .WithMany("Threads")
                        .HasForeignKey("ParentBoardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MessageBoard.Models.User", "User")
                        .WithMany("UserThreads")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
