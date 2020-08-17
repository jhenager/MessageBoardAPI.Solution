using System;
using System.Collections.Generic;

namespace MessageBoard.Models
{
  public class User
  {
    public int UserId { get; set; }
    public string UserName { get; set; }
    public DateTime CreationDate { get; set; }
    public ICollection<Post> UserPosts { get; set; }
    public ICollection<Thread> UserThreads { get; set; }

    public User()
    {
      this.UserPosts = new HashSet<Post>();
      this.UserThreads = new HashSet<Thread>();
    }
  }
}