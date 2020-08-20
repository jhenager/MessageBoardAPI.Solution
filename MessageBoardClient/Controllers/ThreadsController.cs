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
      return View(boardId);
    }

    [HttpPost]
    public IActionResult Create(Thread thread)
    {
      Thread.Post(thread);
      return RedirectToAction("Index");
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
      return RedirectToAction("Index");
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
      return RedirectToAction("Index");
    }
  }
}