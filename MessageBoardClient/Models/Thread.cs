using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MessageBoardClient.Models
{
  public class Thread
  {
    public int ThreadId { get; set; }
    public string Title { get; set; }
    public DateTime CreationDate { get; set; }
    public int ParentBoardId { get; set; }
    public Board ParentBoard { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<Post> Posts { get; set; }

    public Thread()
    {
      this.Posts = new HashSet<Post>();
    }

    public static List<Thread> GetAll()
    {
      var apicallTask = ApiHelper.GetAll("threads");
      var result = apicallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Thread> threadList = JsonConvert.DeserializeObject<List<Thread>>(jsonResponse.ToString());

      return threadList;
    }

    public static Thread GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get("threads", id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Thread thread = JsonConvert.DeserializeObject<Thread>(jsonResponse.ToString());

      return thread;
    }

    public static void Post(Thread thread, int boardId)
    {
      string jsonThread = JsonConvert.SerializeObject(thread);
      var apiCallTask = ApiHelper.PostChild("boards", boardId, "threads", jsonThread);
    }

    public static void Put(Thread thread)
    {
      string jsonThread = JsonConvert.SerializeObject(thread);
      var apiCallTask = ApiHelper.Put("threads", thread.ThreadId, jsonThread);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete("threads", id);
    }
  }
}