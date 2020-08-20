using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardClient.Controllers
{
  public class PostsController : Controller
  {
    public IActionResult Index()
    {
      List<Post> allPosts = Post.GetAll();
      return View(allPosts);
    }

    public IActionResult Details(int id)
    {
      Post thisPost = Post.GetDetails(id);
      return View(thisPost);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Post post)
    {
      Post.Post(post);
      return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
      Post thisPost = Post.GetDetails(id);
      return View(thisPost);
    }

    [HttpPost]
    public IActionResult Update(Post post)
    {
      Post.Put(post);
      return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
      Post thisPost = Post.GetDetails(id);
      return View(thisPost);
    }

    [HttpPost]
    public IActionResult Delete(Post post)
    {
      Post.Delete(post.PostId);
      return RedirectToAction("Index");
    }
  }
}