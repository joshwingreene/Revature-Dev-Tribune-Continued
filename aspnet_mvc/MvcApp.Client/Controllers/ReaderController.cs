
using Microsoft.AspNetCore.Mvc;
using MvcApp.Client.Models.Shared;
using MvcApp.Client.Models.Reader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace MvcApp.Client.Controllers
{
  [Route("[controller]")]
  public class ReaderController:Controller
  {
    private string apiUrl = "https://localhost:5001/";
    private HttpClient _http;

    public ReaderController(){
      HttpClientHandler clientHandler = new HttpClientHandler();
      clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
      _http = new HttpClient(clientHandler);
    }
    [HttpGet("ReaderArticles")]
    public async Task<ActionResult> Get()
    {
      var response = await _http.GetAsync(apiUrl + "Topic/topics");
      if (response.IsSuccessStatusCode)
      {
        var JsonResponse = await response.Content.ReadAsStringAsync();
        var topicModel = JsonConvert.DeserializeObject<List<ViewTopicModel>>(JsonResponse);

        System.Console.WriteLine(topicModel.Count);

        return await Task.FromResult(View("ReaderMain",topicModel));
      }
      return View("error");
    }

    [HttpGet("signup")]
    public ActionResult SignUp()
    {
      return View("ReaderSignup");
    }

// THIS IS THE SIGNUP ACTION //
    [HttpPost("confirm")]
    public IActionResult Confirm(ReaderViewModel model)
    {
      _http.BaseAddress= new Uri(apiUrl+"Reader/CreateReader");
      var postTask = _http.PostAsJsonAsync<ReaderViewModel>("CreateReader",model);
      postTask.Wait();
      var result = postTask.Result;

      ViewBag.message = result.StatusCode;
      if(result.IsSuccessStatusCode)
      {
          return RedirectToAction("get");
      }
      ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
      return View("signup");
    }

// EOF THE SIGNUP ACTION //

    [HttpGet]
    public IActionResult ReaederLogIn()
    {
      return View("ReaderLogin");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(ReaderViewModel reader)
    {
      _http.BaseAddress= new Uri(apiUrl+"Reader/ReaderLogin");
      var postTask = await _http.PostAsJsonAsync<ReaderViewModel>("ReaderLogin",reader);
      ViewBag.message = postTask.StatusCode;
      if(postTask.IsSuccessStatusCode)
      {
        return RedirectToAction("Get");
      }
      ViewBag.type ="Reader";
      return View("ErrorLogin");
    }

    [HttpPost("GetReaderArticles/{topicOption}")]
    public async Task<ActionResult> GetReaderArticles(string topicOption)
    {
      System.Console.WriteLine("YOU HAVE CHOOSEN" + topicOption);
      var article = new List<ArticleViewModel>(){};
      var response = await _http.GetAsync(apiUrl + "article/articles");

      if (response.IsSuccessStatusCode)
      {

          var jsonResponse = await response.Content.ReadAsStringAsync();
          var ObjOrderList = JsonConvert.DeserializeObject<List<ArticleViewModel>>(jsonResponse);
          article = ObjOrderList;
          ViewBag.topic = topicOption;
          return await Task.FromResult(View("TopicNavigation", article));
      }
      return View("error");
    }



  }
}
