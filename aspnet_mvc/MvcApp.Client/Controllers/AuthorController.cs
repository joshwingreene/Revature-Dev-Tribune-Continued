using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using MvcApp.Client.Models.Author;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MvcApp.Client.Controllers
{
  [Route("[controller]")] // route parser
  public class AuthorController : Controller // test change
  {
    private string apiUrl = "https://localhost:5001/";
    private HttpClient _http;

    public AuthorController(){

      HttpClientHandler clientHandler = new HttpClientHandler();
      clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
      _http = new HttpClient(clientHandler);
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var response = await _http.GetAsync(apiUrl + "Topic/topics");

      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        // System.Console.WriteLine(jsonResponse);

        var ObjOrderList = JsonConvert.DeserializeObject<List<TopicViewModel>>(jsonResponse);
        return await Task.FromResult(View("home", ObjOrderList));
      }
      return View("Error");
    }
  }
}
