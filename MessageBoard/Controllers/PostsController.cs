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
    
    //GET for specific post
    [HttpGet("{PostId}")]
    public ActionResult<Post> Get(int PostId)
    {
      return _db.Posts.Include(p => p.User).First(p => p.PostId == PostId);
    }

    [HttpPut("{PostId}")]
    public void Put(int PostId, [FromBody] Post post)
    {
      post.PostId = PostId;
      _db.Entry(post).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{PostId}")]
    public void Delete(int PostId)
    {
      Post postToDelete = _db.Posts.First(p => p.PostId == PostId);
      _db.Posts.Remove(postToDelete);
      _db.SaveChanges();
    }
  }
}