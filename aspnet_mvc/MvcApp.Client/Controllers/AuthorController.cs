using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using MvcApp.Client.Models.Author;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace MvcApp.Client.Controllers
{
  [Route("[controller]")] // route parser
  public class AuthorController : Controller
  {
    private string apiUrl = "https://localhost:8001/";
    private HttpClient _http = new HttpClient();

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var response = await _http.GetAsync(apiUrl + "Topic/GetCtxTopics");

      if (response.IsSuccessStatusCode) // IsSuccessStatusCode
      {
        //var content = Json.Convert<TopicViewModel>(await response.Content.ReadStringAsync());
        var jsonResponse = await response.Content.ReadAsStringAsync();
        System.Console.WriteLine(jsonResponse);
        
        var ObjOrderList = JsonConvert.DeserializeObject<List<TopicViewModel>>(jsonResponse);
        ObjOrderList.ForEach(m => System.Console.WriteLine(m.Name));

        return await Task.FromResult(View("home", ObjOrderList));
        // return View("home", ObjOrderList);
      }
      // return Task.FromResult(View("Error"));
      // asdasd
      return View("Error");
    }
  }
}
