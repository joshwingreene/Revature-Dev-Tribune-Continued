
using Microsoft.AspNetCore.Mvc;
using MvcApp.Client.Models.Reader;
using MvcApp.Client.Models.Shared;
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
            var article = new List<ArticleViewModel>(){};
            var response = await _http.GetAsync(apiUrl + "article/articles");

            if (response.IsSuccessStatusCode)
            {

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var ObjOrderList = JsonConvert.DeserializeObject<List<ArticleViewModel>>(jsonResponse);
                article = ObjOrderList;


                return await Task.FromResult(View("home", article));
            }
            return View("error");
        }

    [HttpGet("signup")]
    public ActionResult SignUp()
    {
      return View("signup");
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
      return View("login");
    }

    [HttpGet("{reader}")]
    public async Task<IActionResult> Login(ReaderViewModel reader)
    {
      System.Console.WriteLine(reader.Email);
      var response = await _http.GetAsync(apiUrl + "Reader/LogIn/");
       if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var ObjOrderList = JsonConvert.DeserializeObject<ReaderViewModel>(jsonResponse);
                System.Console.WriteLine(ObjOrderList.Email);
                return await Task.FromResult(Ok(Content("Logged IN")));
            }
        return Content("error");
    }

  }
}
