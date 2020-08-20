using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardClient.Controllers
{
  public class BoardsController : Controller
  {
    public IActionResult Index()
    {
      List<Board> allBoards = Board.GetAll();
      return View(allBoards);
    }

    public IActionResult Details(int id)
    {
      Board thisBoard = Board.GetDetails(id);
      return View(thisBoard);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Board board)
    {
      Board.Post(board);
      return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
      Board thisBoard = Board.GetDetails(id);
      return View(thisBoard);
    }

    [HttpPost]
    public IActionResult Update(Board board)
    {
      Board.Put(board);
      return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
      Board thisBoard = Board.GetDetails(id);
      return View(thisBoard);
    }

    [HttpPost]
    public IActionResult Delete(Board board)
    {
      Board.Delete(board.BoardId);
      return RedirectToAction("Index");
    }
  }
}