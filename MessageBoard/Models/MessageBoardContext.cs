using Microsoft.EntityFrameworkCore;
using System;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext(DbContextOptions<MessageBoardContext> options)
        : base(options)
        {
        }

    public DbSet<Board> Boards { get; set; }
    public DbSet<Thread> Threads { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Board>()
        .HasData(
          new Board { BoardId = 1, Title = "Politics"},
          new Board { BoardId = 2, Title = "Religions"},
          new Board { BoardId = 3, Title = "Objectively Best Music Genres"}
        );

      builder.Entity<Thread>()
        .HasData(
          new Thread { ThreadId = 1, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 2, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 3, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 4, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 5, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 6, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 7, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 8, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 9, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 10, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 11, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 12, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 13, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 14, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 15, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 16, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 17, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 18, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 19, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 20, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 21, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 22, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 23, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 24, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1},
          new Thread { ThreadId = 25, Title = "Test Message", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1}
        );

      builder.Entity<Post>()
        .HasData(
          new Post { PostId = 1, PostBody = "Lorem Ipsum", Title = "Test Message", UserId = 1, CreationDate = DateTime.Now, ParentThreadId = 1}
        );

      builder.Entity<User>()
        .HasData(
          new User { UserId = 1, UserName = "TestName", CreationDate = DateTime.Now }
        );
    }
  }
}