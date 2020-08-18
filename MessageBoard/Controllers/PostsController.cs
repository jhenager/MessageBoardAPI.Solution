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
  public class PostsController : ControllerBase
  {
    private MessageBoardContext _db;
    public PostsController(MessageBoardContext db)
    {
      _db = db;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> Get(DateTime StartDate, DateTime EndDate)
    {
      IQueryable<Post> postQuery = _db.Posts;
      if (StartDate != null)
      {
        postQuery = postQuery.Where(p => p.CreationDate >= StartDate);
      }
      if (EndDate != null)
      {
        postQuery = postQuery.Where(p => EndDate >= p.CreationDate);
      }
      List<Post> queryResult = await postQuery.ToListAsync();
      return queryResult;
    }
    
    //GET for specific post
    [HttpGet("{PostId}")]
    public async Task<ActionResult<Post>> Get(int PostId)
    {
      Post post = await _db.Posts.Include(p => p.User).FirstAsync(p => p.PostId == PostId);
      return post;
    }

    [HttpPut("{PostId}")]
    public void  Put(int PostId, [FromQuery] int UserId, [FromBody] Post post)
    {
      if (post.UserId == UserId)
      {
        post.PostId = PostId;
        _db.Entry(post).State = EntityState.Modified;
        _db.SaveChanges();
      }
    }

    //http://localhost:5000/api/posts/1?UserId={UserId}
    [HttpDelete("{PostId}")]
    public async Task Delete(int PostId, [FromQuery] int UserId)
    {
      Post postToDelete = await _db.Posts.FirstAsync(p => p.PostId == PostId);
      if (postToDelete.UserId == UserId)
      {
        _db.Posts.Remove(postToDelete);
        _db.SaveChanges();
      }
    }
  }
}