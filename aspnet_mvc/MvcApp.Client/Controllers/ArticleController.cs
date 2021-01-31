using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using MvcApp.Client.Models.Author;
using System.Collections.Generic;
using Newtonsoft.Json;
using MvcApp.Client.Models.Shared;

namespace MvcApp.Client.Controllers
{
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private string apiUrl = "https://localhost:5001/";
        private HttpClient _http;

        public ArticleController(){
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _http = new HttpClient(clientHandler);
        }

        [HttpGet("show_article_creator")]
        public async Task<IActionResult> ShowArticleCreator()
        {
            // Get the topics
            var response = await _http.GetAsync(apiUrl + "Topic/topics");

            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();

                var TopicViewModels = JsonConvert.DeserializeObject<List<TopicViewModel>>(JsonResponse);
                return await Task.FromResult(View("ArticleCreator", TopicViewModels));
            }
            return View("Error");
        }
    }
}