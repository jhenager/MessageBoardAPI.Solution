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
  public class BoardsController : ControllerBase
  {
    private MessageBoardContext _db;
    public BoardsController(MessageBoardContext db)
    {
      _db = db;
    }

    // GET api/boards
    // Get list of all boards
    [HttpGet]
    public ActionResult<IEnumerable<Board>> Get()
    {
      return _db.Boards.ToList();
    }

    // GET api/boards/5
    // get a specific board and all threads of that board
    [HttpGet("{id}")]
    public ActionResult<Board> Get(int id)
    {
      Board board = _db.Boards
        .Include(b => b.Threads)
        .First(b => b.BoardId == id);
      return board;
    }

    // POST api/boards
    //create a new board
    [HttpPost]
    public void Post([FromBody] Board board)
    {
      _db.Boards.Add(board);
      _db.SaveChanges();
    }

    // PUT api/values/5
    // edit an existing board
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Board board)
    {
      board.BoardId = id;
      _db.Entry(board).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/values/5
    // Delete a specific board
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Board board = _db.Boards.First(b => b.BoardId == id);
      _db.Boards.Remove(board);
      _db.SaveChanges();
    }

    // GET api/boards/{BoardId}/threads
    // Get all threads in a single board
    [HttpGet("{BoardId}/threads")]
    public ActionResult<IEnumerable<Thread>> ThreadGet(int BoardId)
    {
      return _db.Threads.Where(t => t.ParentBoardId == BoardId).Include(t => t.User).ToList();
    }

    // POST {BoardId}/threads
    // Create a new thread within a specific board
    [HttpPost("{BoardId}/threads")]
    public void Post(int BoardId, [FromBody] Thread thread)
    {
      Board board = _db.Boards.First(b => b.BoardId == BoardId);
      board.Threads.Add(thread);
      _db.SaveChanges();
    }

    // PUT {BoardId}/threads/{ThreadId}
    // Edit an existing thread within a specific board

    [HttpPut("{BoardId}/threads/{ThreadId}")]
    public void Put(int BoardId, int ThreadId, [FromBody] Thread thread)
    {
      Board board = _db.Boards.First(b => b.BoardId == BoardId);
      thread.ThreadId = ThreadId;
      _db.Entry(thread).State = EntityState.Modified;
      _db.SaveChanges();
    }
  }
}