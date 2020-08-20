using MessageBoardClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardClient.Controllers
{
  public class ThreadsController : Controller
  {
    public IActionResult Index()
    {
      List<Thread> allThreads = Thread.GetAll();
      return View(allThreads);
    }

    public IActionResult Details(int id)
    {
      Thread thisThread = Thread.GetDetails(id);
      return View(thisThread);
    }

    public IActionResult Create(int boardId)
    {
      ViewBag.BoardId = boardId;
      return View();
    }

    [HttpPost]
    public IActionResult Create(Thread thread, int boardId)
    {
      thread.ParentBoardId = boardId;
      thread.CreationDate = DateTime.Now;
      thread.UserId = 1;
      Thread.Post(thread, boardId);
      return RedirectToAction("Details", "Boards", new { id = thread.ParentBoardId });
    }

    public IActionResult Update(int id)
    {
      Thread thisThread = Thread.GetDetails(id);
      return View(thisThread);
    }

    [HttpPost]
    public IActionResult Update(Thread thread)
    {
      Thread.Put(thread);
      return RedirectToAction("Details", new { id = thread.ThreadId });
    }

    public IActionResult Delete(int id)
    {
      Thread thread = Thread.GetDetails(id);
      return View(thread);
    }

    [HttpPost]
    public IActionResult Delete(Thread thread)
    {
      Thread.Delete(thread.ThreadId);
      return RedirectToAction("Details", "Boards", new { id = thread.ParentBoardId });
    }
  }
}