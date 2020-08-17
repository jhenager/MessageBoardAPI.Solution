using System;
using System.Collections.Generic;

namespace MessageBoard.Models
{
  public class Thread
  {
    public int ThreadId { get; set; }
    public string Title { get; set; }
    public DateTime CreationDate { get; set; }
    public Board ParentBoard { get; set; }
    public User User { get; set; }
    public ICollection<Post> Posts { get; set; }

    public Thread()
    {
      this.Posts = new HashSet<Post>();
    }
  }
}