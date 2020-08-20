using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MessageBoardClient.Models
{
  public class Board
  {
    public int BoardId { get; set; }
    public string Title { get; set; }
    public ICollection<Thread> Threads { get; set; }

    public Board()
    {
      this.Threads = new HashSet<Thread>();
    }

    public static List<Board> GetAll()
    {
      ApiHelper apicallTask = ApiHelper.GetAll("boards");
      var result = apicallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Board> boardList = JsonConvert.DeserializeObject<Board>(jsonResponse.ToString());

      return boardList;
    }

    public static Board GetDetails(int id)
    {
      ApiHelper apiCallTask = ApiHelper.Get("boards", id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Board board = JsonConvert.DeserializeObject<Board>(jsonResponse.ToString());

      return board;
    }

    public static void Post(Board board)
    {
      string jsonBoard = JsonConvert.SerializeObject(board);
      var apiCallTask = ApiHelper.Post(jsonBoard);
    }
  }
}