using System;
using System.Collections.Generic;

namespace MessageBoard.Models
{
  public class Post
  {
    public int PostId { get; set; }
    public User User { get; set; }
    public string Title { get; set; }
    public string PostBody { get; set; }
    public DateTime CreationDate { get; set; }
    public Thread ParentThread { get; set; }
  }
}