
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
                // article.Author = "TEST";//ObjOrderList.Author;
                // article.Title = "Title";
                // article.Body = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).";
                // article.Topic = ObjOrderList.Last().Name;
                // article.ImagePath = "#";

                return await Task.FromResult(View("home", article));
            }
            return View("error");
        }
    }
}
