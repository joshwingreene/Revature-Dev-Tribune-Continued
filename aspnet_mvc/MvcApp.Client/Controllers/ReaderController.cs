
using Microsoft.AspNetCore.Mvc;
using MvcApp.Client.Models.Author;
using MvcApp.Client.Models.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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


        [HttpGet]
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
    }
}
