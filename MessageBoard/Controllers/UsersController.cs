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
  public class UsersController : ControllerBase
  {
    private MessageBoardContext _db;

    public UsersController (MessageBoardContext db) 
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
      return _db.Users.OrderBy(u => u.UserName).ToList();
    }

    [HttpGet("{UserId}")]
    public ActionResult<User> Get(int UserId)
    {
      User user = _db.Users
        .Include(u => u.UserThreads)
        .Include(u => u.UserPosts)
        .First(u => u.UserId == UserId);
      return user;
    }

    [HttpPost]
    public void Post([FromBody] User user)
    {
      _db.Users.Add(user);
      _db.SaveChanges();
    }

    [HttpPut("{UserId}")]
    public void Put(int UserId, [FromBody] User user)
    {
      user.UserId = UserId;
      _db.Entry(user).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{UserId}")]
    public void Delete(int UserId)
    {
      var userToRemove = _db.Users.FirstOrDefault(u => u.UserId == UserId);
      _db.Users.Remove(userToRemove);
      _db.SaveChanges();
    }
  }
}