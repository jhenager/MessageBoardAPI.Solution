using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ThreadsController : ControllerBase
  {
    private MessageBoardContext _db;
    public ThreadsController(MessageBoardContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Thread>> Get()
    {
      return _db.Threads.OrderBy(t => t.CreationDate).ToList();
    }

    //api/threads/{ThreadId}
    [HttpGet("{ThreadId}")]
    public ActionResult<Thread> Get(int ThreadId)
    {
      Thread thisThread = _db.Threads.Include(t => t.User).FirstOrDefault(t => t.ThreadId == ThreadId);
      return thisThread;
    }

    [HttpDelete("{ThreadId}")]
    public void Thread(int ThreadId)
    {
      Thread threadToDelete = _db.Threads.FirstOrDefault(t => t.ThreadId == ThreadId);
      _db.Threads.Remove(threadToDelete);
      _db.SaveChanges();
    }

    [HttpGet("{ThreadId}/posts")]
    public ActionResult<IEnumerable<Post>> GetAllPosts(int ThreadId)
    {
      return _db.Posts.Where(p => p.ParentThreadId == ThreadId).Include(p => p.User).ToList();
    }

    [HttpPost("{ThreadId}/posts")]
    public void Post(int ThreadId, [FromBody] Post post)
    {
      post.ParentThreadId = ThreadId;
      _db.Posts.Add(post);
      _db.SaveChanges();
    }
  }
}