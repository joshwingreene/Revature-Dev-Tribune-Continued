using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepoApi.Service.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RepoApi.Service.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TopicController : ControllerBase
  {
    private string apiUrl = "https://localhost:5001/";//https://localhost:5001/Topic/topics
    private HttpClient _http = new HttpClient();

    [HttpGet("GetCtxTopics")]
    public async Task<IActionResult> Get()
    {
      var response = await _http.GetAsync(apiUrl + "Topic/topics");

      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        System.Console.WriteLine(jsonResponse);
        
        List<Topic> ObjOrderList = JsonConvert.DeserializeObject<List<Topic>>(jsonResponse);
        ObjOrderList.ForEach(m => System.Console.WriteLine(m.Name));

        return await Task.FromResult(Ok(ObjOrderList));
        
      }

      return Content("Error, sorry no connection "+response +apiUrl);
    }
  }
}
