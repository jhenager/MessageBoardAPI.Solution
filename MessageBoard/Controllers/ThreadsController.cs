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
    public async Task<ActionResult<IEnumerable<Thread>>> Get([FromQuery] PaginationFilter filter)
    {
      List<Thread> threads = await _db.Threads
        .OrderBy(t => t.CreationDate)
        .Skip((filter.PageNumber - 1) * filter.PageSize)
        .Take(filter.PageSize)
        .ToListAsync();
      return threads;
    }

    //api/threads/{ThreadId}
    [HttpGet("{ThreadId}")]
    public async Task<ActionResult<Thread>> Get(int ThreadId)
    {
      Thread thisThread = await _db.Threads.Include(t => t.User).FirstOrDefaultAsync(t => t.ThreadId == ThreadId);
      return thisThread;
    }

    [HttpDelete("{ThreadId}")]
    public async Task Thread(int ThreadId)
    {
      Thread threadToDelete = await _db.Threads.FirstOrDefaultAsync(t => t.ThreadId == ThreadId);
      _db.Threads.Remove(threadToDelete);
      _db.SaveChanges();
    }

    [HttpGet("{ThreadId}/posts")]
    public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts(int ThreadId, DateTime StartDate, DateTime EndDate)
    {
      IQueryable<Post> postQuery = _db.Posts
        .Where(p => p.ParentThreadId == ThreadId)
        .Include(p => p.User);
      if (StartDate != null)
      {
        postQuery = postQuery.Where(p => p.CreationDate >= StartDate);
      }
      if (EndDate != null)
      {
        postQuery = postQuery.Where(p => EndDate >= p.CreationDate);
      }
      List<Post> threadQuery = await postQuery.ToListAsync();
      return postQuery.ToList();
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