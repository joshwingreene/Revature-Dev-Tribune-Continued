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
    private string apiUrl = "https://localhost:5001/";
    private HttpClient _http;

    public AuthorController(){
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        _http = new HttpClient(clientHandler);
    }


    [HttpGet]
    public IActionResult Home()
    {
        ViewBag.Title = "Login";
        return View("Home");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthorViewModel authorViewModel)
    {
        System.Console.WriteLine("Login");

        System.Console.WriteLine("Email: " + authorViewModel.Email);
        System.Console.WriteLine("Password: " + authorViewModel.Password);

        var response = await _http.GetAsync(apiUrl + "Article/articles");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        System.Console.WriteLine(jsonResponse);
        
        var ObjOrderList = JsonConvert.DeserializeObject<List<ArticleViewModel>>(jsonResponse);
        //ObjOrderList.ForEach(m => System.Console.WriteLine(m.Name));

        return await Task.FromResult(View("AuthorMain", ObjOrderList));

        /*
        return View("AuthorMain", new List<ArticleViewModel> { 
          new ArticleViewModel("First", false),
          new ArticleViewModel("Second", false),
          new ArticleViewModel("Third", true),
          new ArticleViewModel("Four", true),
          new ArticleViewModel("Five", true),
          new ArticleViewModel("Six", true),
        });
        */
    }

    [HttpGet("view_article")]
    public IActionResult ViewArticle()
    {
      return View("AuthorArticleViewer", "tempValue");
    }

    [HttpGet("temp")]
    public async Task<IActionResult> Get()
    {
      var response = await _http.GetAsync(apiUrl + "Topic/topics");

      if (response.IsSuccessStatusCode) // IsSuccessStatusCode
      {
        //var content = Json.Convert<TopicViewModel>(await response.Content.ReadStringAsync());
        var jsonResponse = await response.Content.ReadAsStringAsync();
        System.Console.WriteLine(jsonResponse);
        
        var ObjOrderList = JsonConvert.DeserializeObject<List<TopicViewModel>>(jsonResponse);
        //ObjOrderList.ForEach(m => System.Console.WriteLine(m.Name));

        return await Task.FromResult(View("TopicList", ObjOrderList));
        // return View("home", ObjOrderList);
      }
      // return Task.FromResult(View("Error"));
      // asdasd
      return View("Error");
    }
  }
}
