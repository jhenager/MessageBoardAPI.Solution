using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MessageBoardClient.Models
{
  public class Post
  {
    public int PostId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Title { get; set; }
    public string PostBody { get; set; }
    public DateTime CreationDate { get; set; }
    public int ParentThreadId { get; set; }
    public Thread ParentThread { get; set; }

    public static List<Post> GetAll()
    {
      var apicallTask = ApiHelper.GetAll("posts");
      var result = apicallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Post> postList = JsonConvert.DeserializeObject<List<Post>>(jsonResponse.ToString());

      return postList;
    }

    public static Post GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get("posts", id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Post post = JsonConvert.DeserializeObject<Post>(jsonResponse.ToString());

      return post;
    }

    public static void NewPost(Post thisPost, int threadId)
    {
      string jsonPost = JsonConvert.SerializeObject(thisPost);
      var apiCallTask = ApiHelper.PostChild("threads", threadId, "posts", jsonPost);
    }

    public static void Put(Post post)
    {
      string jsonPost = JsonConvert.SerializeObject(post);
      var apiCallTask = ApiHelper.Put("posts", post.PostId, jsonPost);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete("posts", id);
    }
  }
}