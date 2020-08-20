using System.Threading.Tasks;
using RestSharp;

namespace MessageBoardClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll(string endPoint)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{endPoint}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(string endPoint, int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{endPoint}/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post (string endPoint, string newObject)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{endPoint}", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newObject);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task PostChild (string parentEndpoint, int parentId, string childName, string newObject)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{parentEndpoint}/{parentId}/{childName}", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newObject);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(string endPoint, int id, string newObject)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{endPoint}/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newObject);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(string endPoint, int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{endPoint}/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}