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
    public async Task<ActionResult<IEnumerable<Board>>> Get()
    {
      List<Board> boardList = await _db.Boards.ToListAsync();
      return boardList;
    }

    // GET api/boards/5
    // get a specific board and all threads of that board
    [HttpGet("{id}")]
    public async Task<ActionResult<Board>> Get(int id)
    {
      Board board = await _db.Boards
        .Include(b => b.Threads)
        .FirstAsync(b => b.BoardId == id);
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
    public async Task Delete(int id)
    {
      Board board = await _db.Boards.FirstAsync(b => b.BoardId == id);
      _db.Boards.Remove(board);
      _db.SaveChanges();
    }

    // GET api/boards/{BoardId}/threads
    // Get all threads in a single board
    [HttpGet("{BoardId}/threads")]
    public async Task<ActionResult<IEnumerable<Thread>>> ThreadGet(int BoardId)
    {
      List<Thread> theseThreads = await _db.Threads
        .Where(t => t.ParentBoardId == BoardId)
        .Include(t => t.User)
        .ToListAsync();
      return theseThreads;
    }

    // POST {BoardId}/threads
    // Create a new thread within a specific board
    [HttpPost("{BoardId}/threads")]
    public async Task Post(int BoardId, [FromBody] Thread thread)
    {
      Board board = await _db.Boards.FirstAsync(b => b.BoardId == BoardId);
      board.Threads.Add(thread);
      _db.SaveChanges();
    }

    // PUT {BoardId}/threads/{ThreadId}
    // Edit an existing thread within a specific board

    [HttpPut("{BoardId}/threads/{ThreadId}")]
    public async Task Put(int BoardId, int ThreadId, [FromBody] Thread thread)
    {
      Board board = await _db.Boards.FirstAsync(b => b.BoardId == BoardId);
      thread.ThreadId = ThreadId;
      _db.Entry(thread).State = EntityState.Modified;
      _db.SaveChanges();
    }
  }
}