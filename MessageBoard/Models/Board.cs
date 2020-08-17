using System.Collections.Generic;

namespace MessageBoard.Models
{
  public class Board
  {
    public int BoardId { get; set; }
    public string Title { get; set; }
    public ICollection<Thread> Threads { get; set; }

    public Board()
    {
      this.Threads = new HashSet<Thread>();
    }
  }
}